﻿using System;

namespace Twainsoft.KeyCatcher.Core.Keyboard.Events
{
    public class KeyStrokeEventArgs : EventArgs
    {
        public KeyboardSession KeyboardSession { get; private set; }

        public KeyStrokeEventArgs(KeyboardSession keyboardSession)
        {
            KeyboardSession = keyboardSession;
        }
    }
}