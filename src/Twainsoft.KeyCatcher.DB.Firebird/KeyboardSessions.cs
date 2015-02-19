using FirebirdSql.Data.FirebirdClient;
using Twainsoft.KeyCatcher.Core.Model.Persistence;
using Twainsoft.KeyCatcher.Core.Model.Repositories;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public class KeyboardSessions : IKeyboardSessions
    {
        private IPersistence Persistence { get; set; }

        public KeyboardSessions(IPersistence persistence)
        {
            Persistence = persistence;
        }

        public void Save(KeyboardSession keyboardSession)
        {
            var sql = "INSERT INTO Sessions (SID, Name, Start, End, Keys) VALUES ()";

            using (var saveCommand = new FbCommand("", 
                new FbConnection(Persistence.ConnectionString)))
            {
                
            }
            
        }
    }
}
