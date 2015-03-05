﻿using System;
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
            const string sql = "INSERT INTO \"Sessions\" (\"SID\", \"Name\", \"StartDate\", \"EndDate\", \"InputCulture\", \"InputLanguage\", \"KeyCount\", \"Keys\") " +
                               "VALUES (@SID, @Name, @StartDate, @EndDate, @InputCulture, @InputLanguage, @KeyCount, @Keys);";

            using (var saveCommand = new FbCommand(sql, 
                new FbConnection(Persistence.ConnectionString)))
            {
                saveCommand.Parameters.Add("@SID", Guid.NewGuid());
                saveCommand.Parameters.Add("@Name", keyboardSession.Name);
                saveCommand.Parameters.Add("@StartDate", keyboardSession.Start);
                saveCommand.Parameters.Add("@EndDate", keyboardSession.End);
                saveCommand.Parameters.Add("@InputCulture", keyboardSession.InputLanguage.Culture);
                saveCommand.Parameters.Add("@InputLanguage", keyboardSession.InputLanguage.LayoutName);
                saveCommand.Parameters.Add("@KeyCount", keyboardSession.KeyPressCount);
                saveCommand.Parameters.Add("@Keys", keyboardSession.GetKeys());

                saveCommand.Connection.Open();

                saveCommand.ExecuteNonQuery();

                saveCommand.Connection.Close();
            }
        }

        public int Count()
        {
            const string sql = "SELECT count(*) FROM \"Sessions\";";
            var result = 0;

            using (var saveCommand = new FbCommand(sql,
                new FbConnection(Persistence.ConnectionString)))
            {
                saveCommand.Connection.Open();

                result = (int) saveCommand.ExecuteScalar();

                saveCommand.Connection.Close();
            }

            return result;
        }

        public long CaughtKeyCount()
        {
            const string sql = "SELECT sum(\"KeyCount\") FROM \"Sessions\";";
            var result = 0L;

            using (var saveCommand = new FbCommand(sql,
                new FbConnection(Persistence.ConnectionString)))
            {
                saveCommand.Connection.Open();

                result = (long)saveCommand.ExecuteScalar();

                saveCommand.Connection.Close();
            }

            return result;
        }
    }
}
