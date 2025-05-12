using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLearn.Backend.Database
{
    public abstract class Repository
    {
        protected readonly SqliteConnectionProvider connectionProvider;

        protected Repository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        protected SQLiteConnection GetConnection()
        {
            return connectionProvider.GetConnection();
        }
    }
}
