using System;
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
            const string sql = "INSERT INTO Sessions (SID, Name, Start, End, Keys) VALUES (@SID, @Name, @Start, @End, @Keys);";

            using (var saveCommand = new FbCommand(sql, 
                new FbConnection(Persistence.ConnectionString)))
            {
                saveCommand.Parameters.Add("@SID", Guid.NewGuid());
                saveCommand.Parameters.Add("@Name", keyboardSession.Name);
                saveCommand.Parameters.Add("@Start", keyboardSession.Start);
                saveCommand.Parameters.Add("@End", keyboardSession.End);
                saveCommand.Parameters.Add("@Keys", keyboardSession.GetKeys());

                saveCommand.Connection.Open();

                saveCommand.ExecuteNonQuery();

                saveCommand.Connection.Close();
            }
        }
    }
}
