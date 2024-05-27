using System.Data.SqlClient;
using TransportMangementSystem.Model;
using TransportMangementSystem.Util;


namespace TransportMangementSystem.Repository
{
    public class DriverRepo : IDriverRepo
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public DriverRepo()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
        
        public bool AllocateDriver(int tripId, int driverId)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "SELECT DriverId FROM Trips WHERE TripId = @TripId AND DriverId IS NOT NULL";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TripId", tripId);
                int allocatedDriverId = Convert.ToInt32(cmd.ExecuteScalar());
                if (allocatedDriverId != 0)
                {
                    Console.WriteLine("Trip is already allocated to a driver.");

                    return false;
                }
                cmd.CommandText = "UPDATE Trips SET DriverId = @DriverId WHERE TripId = @TripId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DriverId", driverId);
                cmd.Parameters.AddWithValue("@TripId", tripId);
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE Driver SET Status = 'Allocated' WHERE DriverId = @DriverId";
                cmd.ExecuteNonQuery();
                if (rowsAffected==0)
                {
                    throw new System.Exception();
                }
                return rowsAffected > 0;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Wrong Info given");
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public bool DeallocateDriver(int tripId)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Update Trips set DriverId = NULL where TripId = @TripID;" +
                    "Update Driver set status = 'Available' where DriverId = (Select DriverId from Trips where TripId = @TripId)";
                cmd.Parameters.AddWithValue("@TripId", tripId);
                
                int deallocateDriver = cmd.ExecuteNonQuery();
                if (deallocateDriver == 0)
                {
                    throw new System.Exception();
                }
                return deallocateDriver > 0;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Wrong Info given");
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<Driver> AvailableDrivers()
        {
                cmd.Connection.Open();
                List<Driver> drivers = new List<Driver>();
                cmd.CommandText = "Select * from Driver where Status = 'Available'";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Driver driver = new Driver();
                    driver.DriverId = (int)reader["DriverID"];
                    driver.DriverName = (string)reader["DriverName"];
                    driver.DriverLicense = (string)reader["DriverLicense"];
                    driver.DriverRatings = Convert.ToSingle(reader["DriverRatings"]);
                    driver.DriverStatus = (string)reader["Status"];
                    drivers.Add(driver);
                }
            cmd.Connection.Close();
            return drivers;

        }

        public List<Driver> AllocatedDriver()
        {
            cmd.Connection.Open();
            List<Driver> drivers = new List<Driver>();
            cmd.CommandText = "Select * from Driver where Status = 'Allocated' ";
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Driver driver = new Driver();
                driver.DriverId = (int)reader["DriverID"];
                driver.DriverName = (string)reader["DriverName"];
                driver.DriverLicense = (string)reader["DriverLicense"];
                driver.DriverRatings = Convert.ToSingle(reader["DriverRatings"]);
                driver.DriverStatus = (string)reader["Status"];
                drivers.Add(driver);
            }
            cmd.Connection.Close();
            return drivers;
        }
        public void DisplayDetailsForAllocation()
        {
            cmd.Connection.Open();
            cmd.CommandText = @"select T.TripID, R.StartDestination as Source, R.EndDestination as Destination
                       from Trips T 
                       join Routes R on T.RouteID = R.RouteID
                        where T.Status ='Scheduled' and T.DriverID is null";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int tripId = (int)reader["TripID"];
                string source = (string)reader["Source"];
                string destination = (string)reader["Destination"];
                Console.WriteLine($"Trip ID: {tripId}\t" +
                    $"Source: {source}\t" +
                    $"Destination: {destination}");
            }
            reader.Close();
            cmd.Connection.Close();
        }
        public void DisplayDetailsForDeAllocation()
        {
            cmd.Connection.Open();
            cmd.CommandText = @"select T.TripID, R.StartDestination as Source, R.EndDestination as Destination
                       from Trips T 
                       join Routes R on T.RouteID = R.RouteID
                        where T.Status ='Scheduled' and T.DriverID is not null";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int tripId = (int)reader["TripID"];
                string source = (string)reader["Source"];
                string destination = (string)reader["Destination"];
                Console.WriteLine($"Trip ID: {tripId}\t" +
                    $"Source: {source}\t" +
                    $"Destination: {destination}");
            }
            reader.Close();
            cmd.Connection.Close();
        }
    }
}
