using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Exception;
using TransportMangementSystem.Model;
using TransportMangementSystem.Util;

namespace TransportMangementSystem.Repository
{
    public class BookingRepo : IBookingRepo
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public BookingRepo()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
        public bool BookTrip(int tripId, int passengerId, DateTime bookingDate)
        {
            try
            {
                cmd.Connection.Open(); 
                cmd.CommandText = "INSERT INTO Bookings VALUES (@TripID, @PassengerID, @BookingDate, @Status)";
                cmd.Parameters.AddWithValue("@TripID", tripId);
                cmd.Parameters.AddWithValue("@PassengerID", passengerId);
                cmd.Parameters.AddWithValue("@BookingDate", bookingDate);
                cmd.Parameters.AddWithValue("@Status", "Confirmed");
                int bookTripStatus = cmd.ExecuteNonQuery();
                if (bookTripStatus == 0)
                {
                    throw new BookingNotFoundException("BookingId not found");
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch(BookingNotFoundException ex)
            {
                Console.WriteLine("Booking Id is not Found");
                return false;
            }
          
            finally
            {
                cmd.Connection.Close();
            }
        }

        public bool CancelBooking(int bookingId)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Update Bookings Set Status = 'Cancelled' WHERE BookingID = @BookingId";
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                int cancelTripStatus = cmd.ExecuteNonQuery();
                if (cancelTripStatus == 0)
                {
                    throw new BookingNotFoundException("Id not found");
                }
                return true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (BookingNotFoundException ex)
            {
                Console.WriteLine("Booking Id is not Found");
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public void DisplayConfirmedBookings()
        {
            cmd.Connection.Open();
            cmd.CommandText = @"SELECT B.BookingID, B.TripID, B.BookingDate, P.FirstName AS PassengerName
                        FROM Bookings B
                        INNER JOIN Passengers P ON B.PassengerID = P.PassengerID
                        WHERE B.Status = 'Confirmed'";
            
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Confirmed Bookings:");
            Console.WriteLine("Booking ID\tTrip ID\t\tBooking Date\t\tPassenger Name");
            while (reader.Read())
            {
                int bookingId = (int)reader["BookingID"];
                int tripId = (int)reader["TripID"];
                DateTime bookingDate = (DateTime)reader["BookingDate"];
                string passengerName = (string)reader["PassengerName"];

                Console.WriteLine($"{bookingId}\t\t{tripId}\t\t{bookingDate}\t\t{passengerName}");
            }
            reader.Close();
            cmd.Connection.Close();
        }

        public bool MapDriverToVehicle(Driver driver, Vehicles vehicle,Trips trips)
        {
            if (driver.DriverId == trips.DriverId && vehicle.VehicleId == trips.VehicleId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Bookings> GetBookingsByTrip(int tripId)
        {
            List<Bookings> bookings = new List<Bookings>();
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = @"SELECT B.BookingID, B.TripID, B.BookingDate, B.Status, 
                P.PassengerID, P.FirstName AS PassengerName, 
                P.PhoneNumber AS PassengerPhoneNumber,
                R.StartDestination, R.EndDestination
                FROM Bookings B 
                JOIN Passengers P ON B.PassengerID = P.PassengerID 
                JOIN Trips T ON B.TripID = T.TripID
                JOIN Routes R ON T.RouteID = R.RouteID
                WHERE B.TripID = @TripId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TripId", tripId);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Passengers passenger = new Passengers
                    {
                        PassengersId = (int)reader["PassengerID"],
                        Name = (string)reader["PassengerName"],
                        PhoneNumber = (string)reader["PassengerPhoneNumber"]
                    };
                    Trips trip = new Trips
                    {
                        TripId = (int)reader["TripID"]
                    };
                    Routes route = new Routes
                    {
                        StartDestination = (string)reader["StartDestination"],
                        EndDestination = (string)reader["EndDestination"]
                    };
                    Bookings booking = new Bookings
                    {
                        BookingId = (int)reader["BookingID"],
                        BookingDate = (DateTime)reader["BookingDate"],
                        BookingStatus = (string)reader["Status"],
                        Passengers = passenger,
                        Trips = trip,
                        Routes = route
                    };
                    bookings.Add(booking);
                }
                reader.Close();
                
            }
            catch (BookingNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return bookings;
        }
        public List<Bookings> getBookingsByPassenger(int passengerId)
        {
            List<Bookings> bookings = new List<Bookings>();
            try
            {
                cmd.CommandText = @"select B.BookingID, B.TripID, B.BookingDate, B.Status, 
                P.PassengerID, P.FirstName as PassengerName, 
                P.PhoneNumber as PassengerPhoneNumber,
                R.StartDestination, R.EndDestination,
                D.DriverName,D.DriverLicense
                from Bookings B 
                join Passengers P on B.PassengerID=P.PassengerID 
                join Trips T on B.TripID= T.TripID
                join Routes R on T.RouteID =R.RouteID
                join Driver D on D.DriverID = T.DriverID
                where B.PassengerId = @PassengerId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PassengerId", passengerId);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Passengers passenger = new Passengers
                    {
                        PassengersId = (int)reader["PassengerID"],
                        Name = (string)reader["PassengerName"],
                        PhoneNumber = (string)reader["PassengerPhoneNumber"]
                    };
                    Trips trip = new Trips
                    {
                        TripId = (int)reader["TripID"]
                    };
                    Routes route = new Routes
                    {
                        StartDestination = (string)reader["StartDestination"],
                        EndDestination = (string)reader["EndDestination"]
                    };
                    Driver driver = new Driver
                    {
                        DriverName = (string)reader["DriverName"],
                        DriverLicense = (string)reader["DriverLicense"]

                    };
                    Bookings booking = new Bookings
                    {
                        BookingId = (int)reader["BookingID"],
                        BookingDate = (DateTime)reader["BookingDate"],
                        BookingStatus = (string)reader["Status"],
                        Passengers = passenger,
                        Trips = trip,
                        Routes = route,
                        Driver = driver
                    };
                    bookings.Add(booking);
                }
                reader.Close();
                
            }
            catch (BookingNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return bookings;
        }
        public void GetAllPassenger()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Select PassengerId,FirstName,PhoneNumber from Passengers";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int passengerId = (int)reader["PassengerId"];
                    string passengerName = (string)reader["FirstName"];
                    string phoneNumber = (string)reader["PhoneNumber"];
                    Console.WriteLine($"PassengerId: {passengerId}\t" +
                        $"PassengerName: {passengerName}\t" +
                        $"PhoneNumber: {phoneNumber}");
                }
                reader.Close();
            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}


