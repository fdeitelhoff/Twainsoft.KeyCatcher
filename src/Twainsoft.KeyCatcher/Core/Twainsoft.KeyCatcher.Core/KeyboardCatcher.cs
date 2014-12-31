using System;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace Twainsoft.KeyCatcher.Core
{
    public class KeyboardCatcher
    {
        private KeyboardHookListener KeyboardHookListener { get; set; }

        private long KeyPressCount { get; set; }

        public KeyboardCatcher()
        {
            // TODO: Try out the AppHooker class and whats possible with it.
            KeyboardHookListener = new KeyboardHookListener(new GlobalHooker()) { Enabled = true };
            // TODO: Those key strokes are not necessary in the correct order.
            // TODO: KeyDown and KeyUp are good to catch modifiers or sort of keys.
            KeyboardHookListener.KeyDown += KeyboardHookListenerOnKeyDown;
            KeyboardHookListener.KeyUp += KeyboardHookListenerOnKeyUp;
            // TODO: This is a nice event, but will not handle non-character keys and thats bad!
            KeyboardHookListener.KeyPress += KeyboardHookListenerOnKeyPress;

            KeyPressCount = 0;
        }

        private void KeyboardHookListenerOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine("KeyDown: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" + keyEventArgs.KeyData);
        }

        private void KeyboardHookListenerOnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            KeyPressCount++;

            Console.WriteLine("KeyPress: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" + keyPressEventArgs.KeyChar + "  (" + KeyPressCount + ")");
        }

        private void KeyboardHookListenerOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine("KeyUp: " + DateTime.Now.ToString("hh: mm:ss.FFFFFFF") + "\t\t\t" + keyEventArgs.KeyData);
        }
    }
}
