using Microsoft.Data.SqlClient;

namespace _4_exercise.Connection
{
    public class DbConnection
    {
        private readonly string stringConnection;
        private SqlConnection connection;

        public DbConnection(IConfiguration configuration){
            stringConnection = configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(stringConnection);
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                if(connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ERROR)
            {
                Console.WriteLine("Error: " + ERROR);
            }
            return connection;
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch(Exception ERROR)
            {
                Console.WriteLine("ERROR: " + ERROR);
            }
        }


    }
}
