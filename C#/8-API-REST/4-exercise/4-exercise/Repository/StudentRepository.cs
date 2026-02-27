using _4_exercise.Entity;
using Microsoft.Data.SqlClient;
using _4_exercise.Connection;

namespace _4_exercise.Repository
{
    public class StudentRepository
    {
        private DbConnection cn;
        public StudentRepository(DbConnection cn)
        {
            this.cn = cn;
        }
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            SqlConnection connection = null;

            try
            {
                connection = cn.OpenConnection();
                string sql = "SELECT id, name, age, subject FROM students;";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["name"].ToString(),
                        Age = Convert.ToInt32(reader["age"]),
                        Subject = reader["subject"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ERROR)
            {
                Console.WriteLine("Error " + ERROR);
            }
            finally
            {
                if (connection != null) { cn.CloseConnection(); }
            }
            return students;
        }

        public Student GetById(int id)
        {
            SqlConnection connection = null;
            Student studentFind = null;

            try
            {
                connection = cn.OpenConnection();
                string sql = "SELECT * FROM students WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    studentFind = new Student();
                    studentFind.Id = Convert.ToInt32(reader["id"]);
                    studentFind.Name = reader["name"].ToString();
                    studentFind.Age = Convert.ToInt32(reader["age"]);
                    studentFind.Subject = reader["subject"].ToString();
                }
                reader.Close();
                return studentFind;
                
            }
            catch (Exception ERROR) {
                Console.WriteLine("Error: " + ERROR);
                return studentFind;
            }
            finally{
                if(connection != null)
                {
                    cn.CloseConnection();
                }
            }
        }

        public int AddStudent(string name, int age, string subject)
        {
            SqlConnection connection = null;

            try
            {
                connection = cn.OpenConnection();
                string sql = "INSERT INTO students (name, age, subject) VALUES (@name, @age, @subject)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@subject", subject);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected;

            }
            catch(Exception ERROR)
            {
                Console.WriteLine("ERROR: " + ERROR);
                return 0;
            }
            finally
            {
                if (connection != null) {
                    cn.CloseConnection();
                }
            }
        }

        public int DeleteStudent(int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = cn.OpenConnection();
                string sql = "DELETE FROM students WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected;

            }catch(Exception ERROR)
            {
                Console.WriteLine("ERROR: " + ERROR);
                return 0;
            }
            finally
            {
                if(connection != null)
                {
                    cn.CloseConnection();
                }
            }
        }

        public int UpdateStudent(string name, int age, string subject, int id)
        {
            SqlConnection connection = null;

            try
            {
                connection = cn.OpenConnection();
                string sql = "UPDATE students SET name = @name, age = @age, subject = @subject WHERE id = @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@subject", subject);
                command.Parameters.AddWithValue("@id", id);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ERROR) {
                Console.WriteLine("ERROR: " + ERROR);
                return 0;
            }
            finally
            {
                if(connection != null)
                {
                    cn.CloseConnection();
                }
            }

        }
    }
}


