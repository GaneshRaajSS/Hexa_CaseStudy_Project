using System.Data.SqlClient;
using TransportMangementSystem.Model;
using TransportMangementSystem.Util;

namespace TransportMangementSystem.Repository
{
    internal class PassengersRepo : IPassengersRepo
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public PassengersRepo()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
        public int RegisterPassenger(Passengers passenger)
        {
            try
            {
                cmd.CommandText = @"Insert into Passengers
                output inserted.PassengerId values (@FirstName, @Gender, @Age, @Email, @PhoneNumber, @Password, @Role)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@FirstName", passenger.Name);
                cmd.Parameters.AddWithValue("@Gender", passenger.Gender);
                cmd.Parameters.AddWithValue("@Age", passenger.Age);
                cmd.Parameters.AddWithValue("@Email", passenger.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", passenger.PhoneNumber);
                cmd.Parameters.AddWithValue("@Password", passenger.Password);
                cmd.Parameters.AddWithValue("@Role", "User");

                cmd.Connection.Open();
                int newPassengerId = (int)cmd.ExecuteScalar();
                return newPassengerId;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public Passengers LoginPassenger(int passengerId, string password)
        {
            try
            {
                string name = "";
                cmd.CommandText = "SELECT * FROM Passengers WHERE PassengerID = @PassengerID AND Password = @Password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PassengerID", passengerId);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Passengers
                    {
                        PassengersId = (int)reader["PassengerID"],
                        Name = (string)reader["FirstName"],
                        Gender = (string)reader["Gender"],
                        Age = (int)reader["Age"],
                        Email = (string)reader["Email"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"]
                    };
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid username or password.", Console.ForegroundColor);
                    Console.ResetColor();
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public Passengers GetPassengerById(int id)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Passengers WHERE PassengerId = @PassengerId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PassengerId", id);

                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Passengers
                        {
                            PassengersId = (int)reader["PassengerId"],
                            Name = (string)reader["FirstName"],
                            Gender = (string)reader["Gender"],
                            Age = (int)reader["Age"],
                            Email = (string)reader["Email"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Password = (string)reader["Password"]
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }


    }
}
