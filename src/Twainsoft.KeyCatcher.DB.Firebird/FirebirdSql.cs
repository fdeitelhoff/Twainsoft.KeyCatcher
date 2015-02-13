using System.IO;
using FirebirdSql.Data.FirebirdClient;
using Twainsoft.KeyCatcher.Core.Model.Persistence;

namespace Twainsoft.KeyCatcher.DB.Firebird
{
    public class FirebirdSql : IPersistence
    {
        public FirebirdSql()
        {
            
        }

        public void CreateDatabase(string path, string file)
        {
            // Check if the path and or file already exists.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var databaseFile = Path.Combine(path, file);

            if (!File.Exists(databaseFile))
            {
                FbConnection.CreateDatabase(string.Format("ServerType=1;User=SYSDBA;" +
                    "Password=test;Dialect=3;Database={0}", databaseFile));

                CreateDatabaseSchema();
            }
        }

        private void CreateDatabaseSchema()
        {
            
        }
    }
}
