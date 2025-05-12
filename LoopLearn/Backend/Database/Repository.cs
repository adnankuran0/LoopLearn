using System.Data.SQLite;

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
