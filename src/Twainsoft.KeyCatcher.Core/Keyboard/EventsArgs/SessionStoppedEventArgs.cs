using System;
using Twainsoft.KeyCatcher.Core.Keyboard.Sessions;

namespace Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs
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
