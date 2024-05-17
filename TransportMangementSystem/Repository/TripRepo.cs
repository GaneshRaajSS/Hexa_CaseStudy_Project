using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TransportMangementSystem.Model;
using TransportMangementSystem.Util;

namespace TransportMangementSystem.Repository
{
    public class TripRepo:ITripRepo
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        VehicleRepo vehicles;
        Routes routes;

        public TripRepo()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            vehicles = new VehicleRepo();
            routes = new Routes();
        }
        public bool ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate,int maxPassengers)
        {
            try
            {
                cmd.CommandText = "Insert into Trips values (@VehicleId, @RouteId, @DepartureDate, @Arrival, @Status, @TripType, @MaxPassengers, @DriverId)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                cmd.Parameters.AddWithValue("@RouteId", routeId);
                cmd.Parameters.AddWithValue("@DepartureDate", departureDate);
                cmd.Parameters.AddWithValue("@Arrival", arrivalDate);
                cmd.Parameters.AddWithValue("@Status", "Scheduled");
                cmd.Parameters.AddWithValue("@TripType", "Freight");
                cmd.Parameters.AddWithValue("@MaxPassengers", maxPassengers);
                cmd.Parameters.AddWithValue("@DriverId", DBNull.Value);

                cmd.Connection.Open();
                int scheduleTripStatus = cmd.ExecuteNonQuery();

                if (scheduleTripStatus > 0)
                {
                    cmd.CommandText = "update Vehicles set Status = @Status where VehicleID = @VehicleId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Status", "Booked");
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                    cmd.ExecuteNonQuery();
                }
                return scheduleTripStatus > 0;
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


        public void DisplayRoutes()
        {
            cmd.CommandText = "SELECT * FROM Routes";
            cmd.Connection.Open();
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
            cmd.CommandText = @"SELECT T.TripID, R.StartDestination AS Source, R.EndDestination AS Destination, R.Distance
                        FROM Trips T
                        INNER JOIN Routes R ON T.RouteID = R.RouteID
                        WHERE T.Status = 'Scheduled'";
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

        public bool CancelTrip(int tripId)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Update Trips Set Status = 'Cancelled' WHERE TripId = @TripId";
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
                return cancelTripStatus > 0 ? true : false;
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
    }
}
