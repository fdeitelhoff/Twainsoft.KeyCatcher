using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard.Events
{
    public class SessionStartedEventArgs : EventArgs
    {
        public KeyboardSession KeyboardSession { get; set; }

        public SessionStartedEventArgs(KeyboardSession keyboardSession)
        {
            KeyboardSession = keyboardSession;
        }
    }
}
