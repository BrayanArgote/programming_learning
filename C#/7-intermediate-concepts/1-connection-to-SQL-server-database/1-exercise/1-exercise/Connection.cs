using Microsoft.Data.SqlClient;

public class Connection
{
    private readonly string stringConnection;
    private SqlConnection connection;

    public Connection()
    {
        stringConnection = "Server=localhost;DataBase=pharmacy;Trusted_Connection=True;TrustServerCertificate=True";
        connection = new SqlConnection(stringConnection);
    }

    public SqlConnection OpenConnection()
    {
        try
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            // Console.WriteLine("--- Conect to SQL Server ---");
        }
        catch (Exception ERROR)
        {
            Console.WriteLine("*** Failed to connect: " + ERROR);
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
            // Console.WriteLine("--- Disconnecting... ---");
        }
        catch (Exception ERROR)
        {
            Console.WriteLine("*** Failed to disconect: " + ERROR);
        }
    }
}