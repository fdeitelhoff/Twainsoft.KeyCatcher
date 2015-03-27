using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Twainsoft.KeyCatcher.Core.Model.Sessions
{
    public class KeyboardSession
    {
        public string Name { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public InputLanguage InputLanguage { get; private set; }

        public long KeyPressCount { get; private set; }
        private Dictionary<DateTime, string> PressedKeys { get; set; }

        public KeyboardSession()
        {
            Start = DateTime.Now;
            InputLanguage = InputLanguage.CurrentInputLanguage;

            PressedKeys = new Dictionary<DateTime, string>();
        }

        public void KeyPress(string keyChar)
        {
            KeyPressCount++;

            PressedKeys.Add(DateTime.Now, keyChar);
        }

        public void Stop(string sessionName)
        {
            Name = sessionName;
            End = DateTime.Now;
        }

        public string GetKeys()
        {
            return string.Join("|", PressedKeys.Values);
        }
    }
}
