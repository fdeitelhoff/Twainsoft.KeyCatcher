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
            KeyboardHookListener.KeyPress += KeyboardHookListenerOnKeyPress;

            KeyPressCount = 0;
        }

        private void KeyboardHookListenerOnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            KeyPressCount++;

            Console.WriteLine(KeyPressCount);
        }
    }
}
