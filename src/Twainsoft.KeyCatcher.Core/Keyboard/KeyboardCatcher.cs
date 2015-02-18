using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using Twainsoft.KeyCatcher.Core.Keyboard.Events;
using Twainsoft.KeyCatcher.Core.Model.Catcher;
using Twainsoft.KeyCatcher.Core.Model.Repositories;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.Core.Keyboard
{
    public sealed class KeyboardCatcher : IKeyboardCatcher
    {
        private KeyboardHookListener KeyboardHookListener { get; set; }

        private KeysConverter KeysConverter { get; set; } 

        private KeyboardSession ActiveKeyboardSession { get; set; }

        private bool IsKeyboardInputCatched { get; set; }
        private bool IsCancellationInProgress { get; set; }

        public bool IsSessionActive
        {
            get { return ActiveKeyboardSession != null && IsKeyboardInputCatched; }
        }

        private bool ExitApplication { get; set; }

        private IKeyboardSessions KeyboardSessions { get; set; }

        public delegate void KeyStrokeEventHandler(object sender, KeyStrokeEventArgs e);
        public event KeyStrokeEventHandler KeyStroked;

        public delegate void SessionStartingEventHandler(object sender, SessionStartingEventArgs e);
        public event SessionStartingEventHandler SessionStarting;

        public delegate void SessionStartedEventHandler(object sender, SessionStartedEventArgs e);
        public event SessionStartedEventHandler SessionStarted;

        public delegate void SessionStatusChangingEventHandler(object sender, SessionStatusChangingEventArgs e);
        public event SessionStatusChangingEventHandler SessionStatusChanging;

        public delegate void SessionStatusChangedEventHandler(object sender, SessionStatusChangedEventArgs e);
        public event SessionStatusChangedEventHandler SessionStatusChanged;

        public KeyboardCatcher(IKeyboardSessions keyboardSessions)
        {
            KeyboardSessions = keyboardSessions;

            KeyboardHookListener = new KeyboardHookListener(new GlobalHooker())
            {
                Enabled = true
            };

            // KeyUp for key combinations like starting a session. KeyDown for the complete key handling process.
            KeyboardHookListener.KeyUp += KeyboardHookListenerOnKeyUp;
            KeyboardHookListener.KeyDown += KeyboardHookListenerOnKeyDown;

            // The KeysConverter is culture variant! 
            // Internally the key chars should be culture invariant so the culture is changed to en-US here.
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            KeysConverter = new KeysConverter();

            IsKeyboardInputCatched = false;
            IsCancellationInProgress = false;
        }

        private void KeyboardHookListenerOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            // If we register the session start key combination, and there's currently session cancellation (session data window) in progress, we maybe start a new one.
            if (!IsCancellationInProgress && StartSessionShortCut(keyEventArgs))
            {
                // Ask via event if the current active session should be stopped first if we detect one.
                if (!IsSessionActive || OnSessionStarting())
                {
                    IsKeyboardInputCatched = true;

                    var session = new KeyboardSession();
                    ActiveKeyboardSession = session;

                    OnSessionStarted();
                }
            }
            // If we register the session stop key combination, we stop the currently active session.
            else if (IsSessionActive && !IsCancellationInProgress && StopSessionShortCut(keyEventArgs))
            {
                CancelSession(false);
            }
            // If we register the session discard key combination, we discard the currently active session.
            else if (IsSessionActive && DiscardSessionShortCut(keyEventArgs))
            {
                DiscardSession();
            }
        }

        private void KeyboardHookListenerOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (IsSessionActive)
            {
                var keyChar = KeysConverter.ConvertToInvariantString(keyEventArgs.KeyData);
                Console.WriteLine("KeyUp " + keyChar);

                OnKeyStroke(keyChar);
            }
        }

        private bool StartSessionShortCut(KeyEventArgs keyEventArgs) 
        {
            return keyEventArgs.Shift && keyEventArgs.Control && keyEventArgs.KeyCode == Keys.J;
        }

        private bool StopSessionShortCut(KeyEventArgs keyEventArgs)
        {
            return keyEventArgs.Shift && keyEventArgs.Control && keyEventArgs.KeyCode == Keys.K;
        }

        private bool DiscardSessionShortCut(KeyEventArgs keyEventArgs)
        {
            return keyEventArgs.Shift && keyEventArgs.Control && keyEventArgs.KeyCode == Keys.L;
        }

        private void OnKeyStroke(string keyChar)
        {
            ActiveKeyboardSession.KeyPress(keyChar);

            if (KeyStroked != null)
            {
                KeyStroked(this, new KeyStrokeEventArgs(ActiveKeyboardSession));
            }
        }

        public void CancelSession(bool exitApplication)
        {
            ExitApplication = exitApplication;

            OnSessionStatusChanging("New Session Name");
        }

        public void SaveSession(string sessionName)
        {
            ActiveKeyboardSession.Stop(sessionName);

            KeyboardSessions.Save(ActiveKeyboardSession);

            OnSessionStatusChanged(SessionStatus.Saved);
        }

        public void DiscardSession()
        {
            ActiveKeyboardSession = null;

            OnSessionStatusChanged(SessionStatus.Discarded);
        }

        public void ContinueSession()
        {
            IsKeyboardInputCatched = true;

            OnSessionStatusChanged(SessionStatus.Continued);
        }

        private bool OnSessionStarting()
        {
            if (SessionStarting != null)
            {
                var sessionStartingEventArgs = new SessionStartingEventArgs(true);

                SessionStarting(this, sessionStartingEventArgs);

                return sessionStartingEventArgs.SessionStart;
            }

            return true;
        }

        private void OnSessionStarted()
        {
            if (SessionStarted != null)
            {
                SessionStarted(this, new SessionStartedEventArgs(ActiveKeyboardSession));
            }
        }

        private void OnSessionStatusChanging(string sessionName)
        {
            IsKeyboardInputCatched = false;
            IsCancellationInProgress = true;

            if (SessionStatusChanging != null)
            {
                SessionStatusChanging(this, new SessionStatusChangingEventArgs(sessionName, ExitApplication, ActiveKeyboardSession));
            }
        }

        private void OnSessionStatusChanged(SessionStatus statusChange)
        {
            IsCancellationInProgress = false;

            if (SessionStatusChanged != null)
            {
                SessionStatusChanged(this, new SessionStatusChangedEventArgs(ActiveKeyboardSession, statusChange, ExitApplication));
            }

            if (statusChange == SessionStatus.Discarded || statusChange == SessionStatus.Saved)
            {
                ActiveKeyboardSession = null;
            }
        }
    }
}
