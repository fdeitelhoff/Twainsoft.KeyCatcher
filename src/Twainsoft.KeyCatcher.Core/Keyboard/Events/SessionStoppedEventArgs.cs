using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard.Events
{
    public class SessionStoppedEventArgs : EventArgs
    {
        public KeyboardSession KeyboardSession { get; set; }

        public SessionStoppedEventArgs(KeyboardSession keyboardSession)
        {
            KeyboardSession = keyboardSession;
        }
    }
}
