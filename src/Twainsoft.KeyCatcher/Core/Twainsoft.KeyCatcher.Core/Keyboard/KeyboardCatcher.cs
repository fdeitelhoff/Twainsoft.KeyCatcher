using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace Twainsoft.KeyCatcher.Core.Keyboard
{
    public sealed class KeyboardCatcher
    {
        private KeyboardHookListener KeyboardHookListener { get; set; }

        private KeysConverter KeysConverter { get; set; } 

        private KeyboardSession ActiveKeyboardSession { get; set; }

        public delegate void KeyStrokeEventHandler(object sender, KeyStrokeEventArgs e);
        public event KeyStrokeEventHandler KeyStroked;
        
        public delegate void SessionStartedEventHandler(object sender, SessionStartedEventArgs e);
        public event SessionStartedEventHandler SessionStarted;
        

        private bool IsSessionActive
        {
            get { return ActiveKeyboardSession != null; }
        }

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
        }

        private void KeyboardHookListenerOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            // If we register the session start key combination, we start a new one.
            if (StartSession(keyEventArgs))
            {
                var session = new KeyboardSession();
                ActiveKeyboardSession = session;

                OnSessionStarted();
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

        private bool StartSession(KeyEventArgs keyEventArgs) 
        {
            return keyEventArgs.Shift && keyEventArgs.Control && keyEventArgs.KeyCode == Keys.K;
        }

        private void OnKeyStroke(string keyChar)
        {
            ActiveKeyboardSession.KeyPress(keyChar);

            if (KeyStroked != null)
            {
                KeyStroked(this, new KeyStrokeEventArgs(ActiveKeyboardSession));
            }
        }

        private void OnSessionStarted()
        {
            if (SessionStarted != null)
            {
                SessionStarted(this, new SessionStartedEventArgs(ActiveKeyboardSession));
            }
        }
    }
}
