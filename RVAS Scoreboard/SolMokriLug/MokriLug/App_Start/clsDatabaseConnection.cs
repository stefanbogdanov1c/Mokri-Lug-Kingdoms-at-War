using MySql.Data.MySqlClient;

namespace MokriLug.App_Start
{
    public class clsDatabaseConnection
    {
        private string server = "localhost";
        private string userId = "root";
        private string databaseName = "mokrilugkaw";

        public void CheckIFExists()
        {
            string connectionString = $"server={server}; user id={userId};";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string createDB = $"CREATE DATABASE IF NOT EXISTS {databaseName}";

                using (var command = new MySqlCommand(createDB, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            connectionString += $"database={databaseName}";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
            }
        }

        public void CreateTableIfNOtExists()
        {
            string connectionString = $"server={server}; user id={userId}; database={databaseName}";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string createTable = "CREATE TABLE IF NOT EXISTS `mokrilugkaw`.`users` ( `username` VARCHAR(50) NOT NULL , `won` INT NULL DEFAULT '0' , `lost` INT NULL DEFAULT '0' )";

                using (var command = new MySqlCommand(createTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();

            }
        }
    }
}