using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Twainsoft.KeyCatcher.Core.Model.Sessions
{
    public class KeyboardSession
    {
        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public InputLanguage InputLanguage { get; private set; }

        public long KeyPressCount { get; private set; }
        private List<string> PressedKeys { get; set; }
        private List<DateTime> PressedKeyDateTimes { get; set; }

        public KeyboardSession()
        {
            Start = DateTime.Now;
            InputLanguage = InputLanguage.CurrentInputLanguage;

            PressedKeys = new List<string>();
            PressedKeyDateTimes = new List<DateTime>();
        }

        public KeyboardSession(Guid guid, string name, DateTime start, DateTime end, long keyPressCount)
            : this()
        {
            Guid = guid;
            Name = name;
            Start = start;
            End = end;
            KeyPressCount = keyPressCount;
        }

        public void KeyPress(string keyChar)
        {
            KeyPressCount++;

            PressedKeys.Add(keyChar);
            PressedKeyDateTimes.Add(DateTime.Now);
        }

        public void Stop(string sessionName)
        {
            Name = sessionName;
            End = DateTime.Now;
        }

        public string GetKeys()
        {
            return string.Join("|", PressedKeys);
        }

        public string GetDateTimes()
        {
            var formatted = PressedKeyDateTimes.Select(item => item.Ticks);

            return string.Join("|", formatted);
        }
    }
}
