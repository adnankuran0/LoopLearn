using LoopLearn.Backend.Quiz;
using System.Data.SQLite;

namespace LoopLearn.Backend.Database
{
    public class SqliteConnectionProvider
    {
        private readonly string connectionString;

        public SqliteConnectionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }

    public class DatabaseService
    {
        private SqliteConnectionProvider? connectionProvider;
        public UserRepository userRepository;
        public WordRepository wordRepository;
        public QuestionRepository questionRepository;

        private static DatabaseService? instance;

        public static DatabaseService Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatabaseService();

                return instance;
            }
        }

        public void Initialize (string connectionString)
        {
            connectionProvider = new SqliteConnectionProvider(connectionString);
            userRepository = new UserRepository(connectionProvider);
            wordRepository = new WordRepository(connectionProvider);
            questionRepository = new QuestionRepository(connectionProvider);

            
        }

        public SQLiteConnection GetConnection()
        {
            if (connectionProvider == null)
                throw new InvalidOperationException("ConnectionProvider is not set.");

            return connectionProvider.GetConnection();
        }
    }

}
