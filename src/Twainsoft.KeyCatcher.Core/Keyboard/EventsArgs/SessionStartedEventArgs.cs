using System;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs
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
