﻿using System.Collections.Generic;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.Core.Model.Repositories
{
    public interface IKeyboardSessions
    {
        void Save(KeyboardSession keyboardSession);

        int Count();

        long CaughtKeyCount();

        List<KeyboardSession> All();
    }
}
