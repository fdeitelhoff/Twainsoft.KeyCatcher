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
            if (keyEventArgs.KeyValue >= 37 && keyEventArgs.KeyValue <= 40) // Arrows
            {
                OnKeyStroked();

                Console.WriteLine("KeyUp: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" +
                                  keyEventArgs.KeyData);
            }
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
