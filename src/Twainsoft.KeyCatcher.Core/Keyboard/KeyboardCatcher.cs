using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs;
using Twainsoft.KeyCatcher.Core.Keyboard.Sessions;

namespace Twainsoft.KeyCatcher.Core.Keyboard
{
    public sealed class KeyboardCatcher
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

        private bool IsSessionStartable
        {
            get { return ActiveKeyboardSession == null && !IsCancellationInProgress; }
        }

        public delegate void KeyStrokeEventHandler(object sender, KeyStrokeEventArgs e);
        public event KeyStrokeEventHandler KeyStroked;

        public delegate void SessionStartingEventHandler(object sender, SessionStartingEventArgs e);
        public event SessionStartingEventHandler SessionStarting;

        public delegate void SessionStartedEventHandler(object sender, SessionStartedEventArgs e);
        public event SessionStartedEventHandler SessionStarted;

        public delegate void SessionStoppingEventHandler(object sender, SessionStoppingEventArgs e);
        public event SessionStoppingEventHandler SessionStopping;

        public delegate void SessionStoppedEventHandler(object sender, SessionStoppedEventArgs e);
        public event SessionStoppedEventHandler SessionStopped;

        public delegate void SessionDiscardedEventHandler(object sender, EventArgs e);
        public event SessionDiscardedEventHandler SessionDiscarded;

        public delegate void SessionContinuedEventHandler(object sender, EventArgs e);
        public event SessionContinuedEventHandler SessionContinued;

        public KeyboardCatcher()
        {
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
            // If we register the session start key combination, we start a new one.
            if (StartSessionShortCut(keyEventArgs))
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
            // If we register the session stop key combination, we stop the currently active one.
            else if (IsSessionActive && !IsCancellationInProgress && StopSessionShortCut(keyEventArgs))
            {
                CancelSession();
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
            return keyEventArgs.Shift && keyEventArgs.Control && keyEventArgs.KeyCode == Keys.K;
        }

        private bool StopSessionShortCut(KeyEventArgs keyEventArgs)
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

        public void CancelSession()
        {
            IsKeyboardInputCatched = false;
            IsCancellationInProgress = true;

            OnSessionStopping("New Session Name");
        }

        public void SaveSession(string sessionName)
        {
            ActiveKeyboardSession.Stop(sessionName);
            IsCancellationInProgress = false;

            OnSessionStopped();
        }

        public void DiscardSession()
        {
            ActiveKeyboardSession = null;
            IsCancellationInProgress = false;

            OnSessionDiscarded();
        }

        public void ContinueSession()
        {
            IsKeyboardInputCatched = true;
            IsCancellationInProgress = false;

            OnSessionContinued();
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

        private void OnSessionStopping(string sessionName)
        {
            if (SessionStopping != null)
            {
                SessionStopping(this, new SessionStoppingEventArgs(sessionName));
            }
        }

        private void OnSessionStopped()
        {
            if (SessionStopped != null)
            {
                SessionStopped(this, new SessionStoppedEventArgs(ActiveKeyboardSession));
            }

            ActiveKeyboardSession = null;
        }

        private void OnSessionDiscarded()
        {
            if (SessionDiscarded != null)
            {
                SessionDiscarded(this, EventArgs.Empty);
            }
        }

        private void OnSessionContinued()
        {
            if (SessionContinued != null)
            {
                SessionContinued(this, EventArgs.Empty);
            }
        }
    }
}
