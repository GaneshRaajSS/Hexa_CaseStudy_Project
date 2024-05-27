using System.Data.SqlClient;
using TransportMangementSystem.Util;

namespace TransportMangementSystem.Repository
{
    public class TripRepo:ITripRepo
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public TripRepo()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
        public int ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate, int maxPassengers)
        {
            int scheduledTripId = -1;
            try
            {
                decimal distance;
                cmd.CommandText = "Select Distance from Routes where RouteID = @RouteId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@RouteId", routeId);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    distance = Convert.ToDecimal(result);
                }
                else
                {
                    throw new System.Exception("Route not found.");
                }
                cmd.CommandText = "Insert into Trips (VehicleId, RouteId, DepartureDate, Arrival, Status, TripType, MaxPassengers, DriverId) " +
                                  "OUTPUT INSERTED.TripID " +
                                  "values (@VehicleId, @RouteId, @DepartureDate, @Arrival, @Status, @TripType, @MaxPassengers, @DriverId)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                cmd.Parameters.AddWithValue("@RouteId", routeId);
                cmd.Parameters.AddWithValue("@DepartureDate", departureDate);
                cmd.Parameters.AddWithValue("@Arrival", arrivalDate);
                cmd.Parameters.AddWithValue("@Status", "Scheduled");
                cmd.Parameters.AddWithValue("@TripType", "Freight");
                cmd.Parameters.AddWithValue("@MaxPassengers", maxPassengers);
                cmd.Parameters.AddWithValue("@DriverId", DBNull.Value);

                scheduledTripId = Convert.ToInt32(cmd.ExecuteScalar());

                if (scheduledTripId > 0)
                {
                    cmd.CommandText = "update Vehicles set Status = @Status where VehicleID = @VehicleId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Status", "Booked");
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                    cmd.ExecuteNonQuery();
                    decimal price = distance * 8 * maxPassengers;
                    cmd.CommandText = "update Routes set Price = @Price where RouteID = @RouteId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@RouteId", routeId);
                    cmd.ExecuteNonQuery();
                }
                return scheduledTripId;
            }
            catch (System.Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return -1;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public void DisplayRoutes()
        {
            cmd.CommandText = "select * from Routes";
            cmd.Connection.Open();
            cmd.Parameters.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Available Routes:");
            Console.WriteLine("Route ID\tSource\t\tDestination\tDistance");
            while (reader.Read())
            {
                int routeId = (int)reader["RouteID"];
                string source = (string)reader["StartDestination"];
                string destination = (string)reader["EndDestination"];
                decimal distance = (decimal)reader["Distance"];

                Console.WriteLine($"{routeId}\t\t{source}\t\t{destination}\t\t{distance}");
            }
            reader.Close();
            cmd.Connection.Close();
        }

        public void DisplayTrips()
        {
            cmd.CommandText = @"select T.TripID, R.StartDestination as Source, R.EndDestination as Destination, R.Distance
                        from Trips T
                        join Routes R on T.RouteID = R.RouteID";
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Trip Details:");
            Console.WriteLine("Trip ID\tSource\t\tDestination\tDistance");
            while (reader.Read())
            {
                int tripId = (int)reader["TripID"];
                string source = (string)reader["Source"];
                string destination = (string)reader["Destination"];
                decimal distance = (decimal)reader["Distance"];
                Console.WriteLine($"{tripId}\t{source}\t{destination}\t{distance}");
            }
            reader.Close();
            cmd.Connection.Close();
        }
        public void DisplayScheduledTripDetails(int tripId)
        {
            try
            {
                cmd.CommandText = @"select T.TripID, R.StartDestination as Source, R.EndDestination as Destination, R.Distance, R.Price
                            from Trips T
                            join Routes R on T.RouteID = R.RouteID
                            where T.Status = 'Scheduled' and T.TripID = @TripId";

                cmd.Parameters.AddWithValue("@TripId", tripId);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Trip Details:");
                Console.WriteLine("Trip ID\tSource\tDestination\tDistance\tPrice");
                if (reader.Read())
                {
                    tripId = (int)reader["TripID"];
                    string source = (string)reader["Source"];
                    string destination = (string)reader["Destination"];
                    decimal distance = (decimal)reader["Distance"];
                    decimal price = (decimal)reader["Price"];
                    Console.WriteLine($"{tripId}\t{source}\t{destination}\t\t\t{distance}\t{price}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No scheduled trip found with the provided Trip ID.",Console.ForegroundColor);
                    Console.ResetColor();
                }
                reader.Close();
            }
            catch (System.Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }


        public bool CancelTrip(int tripId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection.Open();

                cmd.CommandText = "Update Trips Set Status = 'Cancelled' where TripId = @TripId";
                cmd.Parameters.AddWithValue("@TripId", tripId);

                int cancelTripStatus = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                if (cancelTripStatus > 0)
                {
                    cmd.CommandText = "select VehicleID from Trips where TripId = @TripId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TripId", tripId);
                    cmd.Connection.Open();
                    int vehicleId = (int)cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    cmd.CommandText = "update Vehicles set Status = @Status where VehicleID = @VehicleId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Status", "Available");
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                return cancelTripStatus > 0;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public void DisplayTripsForCancelation()
        {
            cmd.CommandText = @"select T.TripID, R.StartDestination as Source, R.EndDestination as Destination, R.Distance,D.DriverID
                        from Trips T
                        join Routes R on T.RouteID = R.RouteID
                        join Driver D on T.DriverID = D.DriverID
                        where T.Status = 'Scheduled'";
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Trip Details:");
            Console.WriteLine("Trip ID\t\tSource\t\tDestination\t\tDistance\t\tDriverId");
            while (reader.Read())
            {
                int tripId = (int)reader["TripID"];
                string source = (string)reader["Source"];
                string destination = (string)reader["Destination"];
                decimal distance = (decimal)reader["Distance"];
                int driverId = (int)reader["DriverID"];
                Console.WriteLine($"{tripId}\t\t{source}\t\t{destination}\t\t{distance}\t\t{driverId}");
            }
            reader.Close();
            cmd.Connection.Close();
        }
    }
}
