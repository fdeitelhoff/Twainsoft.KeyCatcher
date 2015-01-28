﻿using System;
using Twainsoft.KeyCatcher.Core.Keyboard.Sessions;

namespace Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs
{
    public class SessionStatusChangedEventArgs : EventArgs
    {
        public KeyboardSession KeyboardSession { get; private set; }
        public SessionStatus StatusChange { get; private set; }

        public SessionStatusChangedEventArgs(KeyboardSession keyboardSession, SessionStatus statusChange)
        {
            KeyboardSession = keyboardSession;
            StatusChange = statusChange;
        }
    }
}
