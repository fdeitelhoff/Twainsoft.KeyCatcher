using System;

namespace Twainsoft.KeyCatcher.Core
{
    public class KeyboardSession
    {
        public DateTime StartDate { get; private set; }

        public long KeyPressCount { get; private set; }

        public KeyboardSession()
        {
            StartDate = DateTime.Now;
        }

        public void KeyPress()
        {
            KeyPressCount++;
        }
    }
}
