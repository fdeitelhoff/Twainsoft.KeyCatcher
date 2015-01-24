using System;
using System.Collections.Generic;

namespace Twainsoft.KeyCatcher.Core.Keyboard.Sessions
{
    public class KeyboardSession
    {
        public string Name { get; set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public long KeyPressCount { get; private set; }
        private List<string> PressedKeys { get; set; }

        public KeyboardSession()
        {
            Start = DateTime.Now;

            PressedKeys = new List<string>();
        }

        public void KeyPress(string keyChar)
        {
            KeyPressCount++;

            PressedKeys.Add(keyChar);
        }

        public void Stop(string sessionName)
        {
            Name = sessionName;
            End = DateTime.Now;
        }
    }
}
