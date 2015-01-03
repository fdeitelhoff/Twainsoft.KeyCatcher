using System;
using System.Globalization;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using Twainsoft.KeyCatcher.Core.Keyboard;

namespace Twainsoft.KeyCatcher.Core
{
    public class KeyboardCatcher
    {
        private KeyboardHookListener KeyboardHookListener { get; set; }

        private long KeyPressCount { get; set; }

        public delegate void KeyStrokeEventHandler(object sender, KeyStrokeEventArgs e);

        public event KeyStrokeEventHandler KeyStroked;

        public KeyboardCatcher()
        {
            // TODO: Try out the AppHooker class and whats possible with it.
            KeyboardHookListener = new KeyboardHookListener(new GlobalHooker()) { Enabled = true };
            // TODO: Those key strokes are not necessary in the correct order.
            // TODO: KeyDown and KeyUp are good to catch modifiers or sort of keys.
            // Temporary remove of KeyDown. I think KeyUp for modifiers and so on will work.
            //KeyboardHookListener.KeyDown += KeyboardHookListenerOnKeyDown;
            KeyboardHookListener.KeyUp += KeyboardHookListenerOnKeyUp;
            // TODO: This is a nice event, but will not handle non-character keys and thats bad!
            KeyboardHookListener.KeyPress += KeyboardHookListenerOnKeyPress;

            KeyPressCount = 0;
        }

        /*private void KeyboardHookListenerOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine("KeyDown: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" + keyEventArgs.KeyData);
        }*/

        private void KeyboardHookListenerOnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            OnKeyStroked();

            // TODO: Maybe prevent some keystrokes here and catch them in the KeyUp handler? Enter or something else? Could be difficult!
            Console.WriteLine("KeyPress: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" +
                                  keyPressEventArgs.KeyChar + "  (" + KeyPressCount + ")");
        }

        private void KeyboardHookListenerOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            // Catch all keys that are not handled by the KeyPressed event.
            if (CheckKeyValues(keyEventArgs))
            {
                OnKeyStroked();

                Console.WriteLine("KeyUp: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" +
                                  keyEventArgs.KeyData + "  (" + KeyPressCount + ")  " + keyEventArgs.KeyValue);
            }
            else
            {
                Console.WriteLine("KeyUp currently not handled: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") +
                                  "\t\t\t" +
                                  keyEventArgs.KeyData + "  " + keyEventArgs.KeyValue);
            }
        }

        private bool CheckKeyValues(KeyEventArgs keyEventArgs)
        {
            // TODO: Maybe this can be combined in the future or expressed in completely a different way.
            return 
                ((keyEventArgs.KeyValue >= 19 && keyEventArgs.KeyValue <= 20)           // Pause, Capital
                || (keyEventArgs.KeyValue >= 33 && keyEventArgs.KeyValue <= 40)         // PageUp, Next, End, Home, Arrows (Left, Up, Right, Down)
                || (keyEventArgs.KeyValue >= 44 && keyEventArgs.KeyValue <= 46)         // PrintScreen, Insert, Delete
                || (keyEventArgs.KeyValue >= 48 && keyEventArgs.KeyValue <= 57)         // ALT + 1..0 => \ ²³{[]} (not all keys are assigned)
                || (keyEventArgs.KeyValue >= 160 && keyEventArgs.KeyValue <= 164)       // Left-Shift, Right-Shift, Left-Control, Right-Control, Alt
                || (keyEventArgs.KeyValue >= 112 && keyEventArgs.KeyValue <= 123)       // F1..F12
                || (keyEventArgs.KeyValue >= 219 && keyEventArgs.KeyValue <= 221)       // \ (OemOpenBrackets), ^ and °, ´ and `
                || keyEventArgs.KeyValue == 12 || keyEventArgs.KeyValue == 91           // Clear, Left-Windows
                || keyEventArgs.KeyValue == 144);                                       // NumLock
        }

        protected virtual void OnKeyStroked()
        {
            KeyPressCount++;

            if (KeyStroked != null)
            {
                KeyStroked(this, new KeyStrokeEventArgs(KeyPressCount));
            }
        }
    }
}
