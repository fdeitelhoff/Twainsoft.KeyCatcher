using System;
using System.Collections.Generic;

namespace Twainsoft.KeyCatcher.Core.Keyboard
{
    public class KeyboardSession
    {
        public DateTime StartDate { get; private set; }

        public long KeyPressCount { get; private set; }
        private List<string> PressedKeys { get; set; }

        public KeyboardSession()
        {
            StartDate = DateTime.Now;

            PressedKeys = new List<string>();
        }

        public void KeyPress(string keyChar)
        {
            KeyPressCount++;

            PressedKeys.Add(keyChar);
        }
    }
}
