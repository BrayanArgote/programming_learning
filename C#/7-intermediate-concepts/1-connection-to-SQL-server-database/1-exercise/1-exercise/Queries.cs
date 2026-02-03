using Microsoft.Data.SqlClient;

public class Queries
{
    private readonly Connection cn;

    public Queries()
    {
        cn = new Connection();
    }

    public void GetAllCustomers()
    {
        try
        {
            SqlConnection temporalConnection = cn.OpenConnection();

            string sql = "SELECT name, address, phone_number FROM customers";

            SqlCommand command = new SqlCommand(sql, temporalConnection);

            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine(new string('-', 65));
            Console.WriteLine("{0, -20} | {1, -25} | {2, -10} |", "NAME", "ADDRESS", "PHONE NUMBER");
            Console.WriteLine(new string('-', 65));

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string address = reader["address"].ToString();
                string phone_number = reader["phone_number"].ToString();
                Console.WriteLine("{0, -20} | {1, -25} | {2, -10} |", name, address, phone_number);
            }
            Console.WriteLine(new string('-', 65));
            reader.Close();
            command.Dispose();
            cn.CloseConnection();
        }catch(Exception ERROR)
        {
            Console.WriteLine("*** Failed to get data: " + ERROR);
        }
    }

    public void GetAllProducts()
    {
        try
        {
            SqlConnection temporalConnection = cn.OpenConnection();

            string sql = "SELECT * FROM products";

            SqlCommand command = new SqlCommand(sql, temporalConnection);

            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine(new string('-', 74));
            Console.WriteLine("{0, -3} | {1, -20} | {2, -25} | {3, -7} | {4, -5} |", "ID", "NAME", "DESCRIPTION", "PRICE", "STOCK");
            Console.WriteLine(new string('-', 74));

            while (reader.Read())
            {
                string id = reader["id_product"].ToString();
                string name = reader["name"].ToString();
                string description = reader["description"].ToString();
                string price = reader["price"].ToString();
                string stock = reader["stock"].ToString();
                Console.WriteLine("{0, -3} | {1, -20} | {2, -25} | {3, -7} | {4, -5} |", id, name, description, price, stock);
            }
            Console.WriteLine(new string('-', 74));

            reader.Close();
            command.Dispose(); 
            cn.CloseConnection();

        }catch(Exception ERROR)
        {
            Console.WriteLine("*** Failed to get data: " + ERROR);
        }
    }

    public void GetProductById(int id)
    {
        try
        {

            SqlConnection temporalConnection = cn.OpenConnection();

            string sql = "SELECT * FROM products WHERE id_product = @id";

            SqlCommand command = new SqlCommand(sql, temporalConnection);

            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine($"*** Product with the id *{id}* does not exist ***");
            }
            else
            {
                Console.WriteLine(new string('-',74));
                Console.WriteLine("{0, -3} | {1, -20} | {2, -25} | {3, -7} | {4, -5} |", "ID", "NAME", "DESCRIPTION", "PRICE", "STOCK");
                Console.WriteLine(new string('-', 74));

                while (reader.Read())
                {
                    string idB = reader["Id_product"].ToString();
                    string name = reader["name"].ToString();
                    string description = reader["description"].ToString();
                    string price = reader["price"].ToString();
                    string stock = reader["stock"].ToString();
                    Console.WriteLine("{0, -3} | {1, -20} | {2, -25} | {3, -7} | {4, -5} |", idB, name, description, price, stock);
                }
                Console.WriteLine(new string('-', 74));
            }
            reader.Close();
            command.Dispose();
            cn.CloseConnection();
        }catch(Exception ERROR)
        {
            Console.WriteLine("*** Failed to get data: " + ERROR);
        }
    }

    public void AddCustomer(string name, string address, string phone_number)
    {
        SqlConnection temporalConnection = cn.OpenConnection();

        string sql = "INSERT INTO customers(name, address, phone_number) VALUES (@name, @address, @phone_number)";

        SqlCommand command = new SqlCommand(sql, temporalConnection);

        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@address", address);
        command.Parameters.AddWithValue("@phone_number", phone_number);

        try
        {
            int rowsAffect = command.ExecuteNonQuery();
                if (rowsAffect > 0) { Console.WriteLine("--- Customers added exit ---"); }
        }
        catch(Exception ERROR)
        {
            Console.WriteLine("*** Failied to add a customer: " + ERROR);
        }
        finally
        {
            cn.CloseConnection();
            command.Dispose();
        }
    }

    public void DeleteSale(int id)
    {
        SqlConnection temporalConnection = cn.OpenConnection();

        string sql = "DELETE FROM sales WHERE id_sale = @id";

        SqlCommand command = new SqlCommand(sql, temporalConnection);

        command.Parameters.AddWithValue("@id", id);

        try
        {
            int rowAffect = command.ExecuteNonQuery();
            if (rowAffect > 0) { Console.WriteLine("--- One Sale was deleted ---"); }
            else { Console.WriteLine($"--- Sale with the id {id} was not found ---"); }
        }
        catch (Exception ERROR)
        {
            Console.WriteLine("*** Failed to execute the query: " + ERROR);
        }
        finally
        {
            command.Dispose ();
            cn.CloseConnection();
        }


    }


}