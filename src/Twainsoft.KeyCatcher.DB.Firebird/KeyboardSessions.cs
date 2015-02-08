using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public class KeyboardSessions
    {
        public void Add(KeyboardSession keyboardSession)
        {
            using (var ctx = new KeyboardSessionContext())
            {
                ctx.KeyboardSessions.Add(keyboardSession);
                ctx.SaveChanges();
            }
        }
    }
}
