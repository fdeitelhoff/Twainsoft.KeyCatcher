using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace Twainsoft.KeyCatcher.Core.Keyboard
{
    public sealed class KeyboardCatcher
    {
        private KeyboardHookListener KeyboardHookListener { get; set; }

        // TODO: I don't know at this time if it's necessary to save all (previous) sessions.
        private List<KeyboardSession> KeyboardSessions { get; set; }
        private KeyboardSession ActiveKeyboardSession { get; set; }

        public event KeyStrokeEventHandler KeyStroked;
        public delegate void KeyStrokeEventHandler(object sender, KeyStrokeEventArgs e);

        public bool IsSessionActive
        {
            get { return ActiveKeyboardSession != null; }
        }

        public KeyboardCatcher()
        {
            KeyboardHookListener = new KeyboardHookListener(new GlobalHooker())
            {
                Enabled = true
            };

            // We need the KeyPress and KeyUp events for normal and special keys.
            KeyboardHookListener.KeyPress += KeyboardHookListenerOnKeyPress;
            KeyboardHookListener.KeyUp += KeyboardHookListenerOnKeyUp;

            KeyboardSessions = new List<KeyboardSession>();
        }

        private void KeyboardHookListenerOnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            if (IsSessionActive)
            {
                OnKeyStroked();

                // TODO: Maybe prevent some keystrokes here and catch them in the KeyUp handler? Enter or something else? Could be difficult!
                Console.WriteLine("KeyPress: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" +
                                  keyPressEventArgs.KeyChar + "  (" + ActiveKeyboardSession.KeyPressCount + ")");
            }
        }

        private void KeyboardHookListenerOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            // If we register the session start key combination, we start a new one.
            if (StartSession(keyEventArgs))
            {
                var session = new KeyboardSession();
                ActiveKeyboardSession = session;
                KeyboardSessions.Add(session);
            }
            else if (IsSessionActive)
            {
                // Catch all keys that are not handled by the KeyPressed event.
                if (CheckKeyValueRanges(keyEventArgs))
                {
                    OnKeyStroked();

                    Console.WriteLine("KeyUp: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" +
                                      keyEventArgs.KeyData + "  (" + ActiveKeyboardSession.KeyPressCount + ")  " + keyEventArgs.KeyValue +
                                      "   " +
                                      keyEventArgs.KeyCode);
                }
                else
                {
                    Console.WriteLine("KeyUp currently not handled: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") +
                                      "\t\t\t" + keyEventArgs.KeyData + "  " + keyEventArgs.KeyValue);
                }
            }
        }

        private bool StartSession(KeyEventArgs keyEventArgs)
        {
            return keyEventArgs.Shift && keyEventArgs.Control && keyEventArgs.KeyCode == Keys.K;
        }

        private bool CheckKeyValueRanges(KeyEventArgs keyEventArgs)
        {
            // TODO: Maybe this can be combined in the future or expressed in completely a different way.
            return 
                ((keyEventArgs.KeyValue >= 19 && keyEventArgs.KeyValue <= 20)           // Pause, Capital
                || (keyEventArgs.KeyValue >= 33 && keyEventArgs.KeyValue <= 40)         // PageUp, Next, End, Home, Arrows (Left, Up, Right, Down)
                || (keyEventArgs.KeyValue >= 44 && keyEventArgs.KeyValue <= 46)         // PrintScreen, Insert, Delete
                || (keyEventArgs.Alt && keyEventArgs.KeyValue >= 48 && keyEventArgs.KeyValue <= 57)         // ALT + 1..0 => \ ²³{[]} (not all keys are assigned)
                || (keyEventArgs.KeyValue >= 160 && keyEventArgs.KeyValue <= 164)       // Left-Shift, Right-Shift, Left-Control, Right-Control, Alt
                || (keyEventArgs.KeyValue >= 112 && keyEventArgs.KeyValue <= 123)       // F1..F12
                || (keyEventArgs.KeyValue >= 219 && keyEventArgs.KeyValue <= 221)       // \ (OemOpenBrackets), ^ and °, ´ and `
                || keyEventArgs.KeyValue == 12 || keyEventArgs.KeyValue == 91           // Clear, Left-Windows
                || keyEventArgs.KeyValue == 144);                                       // NumLock
        }

        private void OnKeyStroked()
        {
            ActiveKeyboardSession.KeyPress();

            if (KeyStroked != null)
            {
                KeyStroked(this, new KeyStrokeEventArgs(ActiveKeyboardSession));
            }
        }
    }
}
