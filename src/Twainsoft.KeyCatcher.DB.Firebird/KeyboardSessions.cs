using Twainsoft.KeyCatcher.Core.Model.Repositories;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public class KeyboardSessions : IKeyboardSessions
    {
        public void Create(KeyboardSession keyboardSession)
        {
            using (var ctx = new KeyboardSessionContext())
            {
                ctx.KeyboardSessions.Add(keyboardSession);
                ctx.SaveChanges();
            }
        }
    }
}
