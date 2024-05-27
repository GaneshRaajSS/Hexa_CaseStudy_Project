
using System.Data;
using System.Data.SqlClient;

using TransportMangementSystem.Exception;
using TransportMangementSystem.Model;
using TransportMangementSystem.Util;

namespace TransportMangementSystem.Repository
{
    public class BookingRepo : IBookingRepo
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        Passengers passengers = new Passengers();

        public BookingRepo()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
        public bool BookTrip(int tripId, Passengers user,int passengerId)
        {
            if (passengers.CheckIfUserIsAdmin())
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandText = "INSERT INTO Bookings VALUES (@TripID, @PassengerID, @BookingDate, @Status)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TripID", tripId);
                    cmd.Parameters.AddWithValue("@PassengerID", passengerId);
                    cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
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
            else
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandText = "INSERT INTO Bookings VALUES (@TripID, @PassengerID, @BookingDate, @Status)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TripID", tripId);
                    cmd.Parameters.AddWithValue("@PassengerID", user.PassengersId);
                    cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
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
        }
        public bool CancelBooking(int userId,int bookingId)
        {
            Passengers users = new Passengers();
            if (users.Role == "Admin")
            {
                try
                {

                    if (userId == 0)
                    {
                        Console.WriteLine("User is not logged in.");
                        return false;
                    }

                    cmd.Connection.Open();
                    cmd.CommandText = "Update Bookings Set Status = 'Cancelled' WHERE BookingID = @BookingId AND PassengerID = @PassengerId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cmd.Parameters.AddWithValue("@PassengerId", userId);

                    int cancelTripStatus = cmd.ExecuteNonQuery();
                    if (cancelTripStatus == 0)
                    {
                        throw new BookingNotFoundException("Booking not found for the specified user.");
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
            else
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandText = "Update Bookings Set Status = 'Cancelled' WHERE BookingID = @BookingId";
                    cmd.Parameters.Clear();
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
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        
        public void DisplayConfirmedBookings(int userId)
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = @"SELECT B.BookingID, B.TripID, B.BookingDate, P.FirstName AS PassengerName
             FROM Bookings B
             INNER JOIN Passengers P ON B.PassengerID = P.PassengerID
             WHERE B.Status = 'Confirmed' AND B.PassengerID = @UserId";
                cmd.Parameters.AddWithValue("@UserId", userId);

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
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void DisplayConfirmedBookings()
        {
            try
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
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
            }
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
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
        public List<Bookings> GetBookingsByTrip(int tripId, int userId)
        {
            List<Bookings> bookings = new List<Bookings>();
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = @"SELECT B.BookingID, B.TripID, B.BookingDate, B.Status, 
                                B.PassengerID, P.FirstName AS PassengerName, 
                                P.PhoneNumber AS PassengerPhoneNumber,
                                R.StartDestination, R.EndDestination, R.Distance
                                FROM Bookings B 
                                JOIN Passengers P ON B.PassengerID = P.PassengerID 
                                JOIN Trips T ON B.TripID = T.TripID
                                JOIN Routes R ON T.RouteID = R.RouteID
                                WHERE B.TripID = @TripId AND B.PassengerID = @UserId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TripId", tripId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Passengers passenger = new Passengers
                    {
                        PassengersId = (int)reader["PassengerID"],
                        Name = (string)reader["PassengerName"],
                        PhoneNumber = (string)reader["PassengerPhoneNumber"]
                    };
                    Routes route = new Routes
                    {
                        StartDestination = (string)reader["StartDestination"],
                        EndDestination = (string)reader["EndDestination"],
                        Distance = (decimal)reader["Distance"]
                    };
                    Trips trip = new Trips
                    {
                        TripId = (int)reader["TripID"],
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
                if (bookings.Count == 0)
                {
                    throw new BookingNotFoundException($"No bookings found for TripId: {tripId}");
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (BookingNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return bookings;
        }

        public int GetTripIdByUserId(int userId)
        {
            int tripId = -1;

            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Select TripId from bookings where PassengerID = @UserId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserId", userId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    tripId = Convert.ToInt32(result);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return tripId;
        }

        public void DisplayTrips()
        {
            try
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
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public List<Bookings> GetBookingsByPassenger(int passengerId)
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
                        //Price = reader.IsDBNull(reader.GetOrdinal("Price"))? 0 : Convert.ToDecimal(reader["Price"])
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
                
                if (bookings.Count == 0)
                {
                    throw new BookingNotFoundException($"No bookings found for passenger ID: {passengerId}");
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(BookingNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return bookings;
        }
        public List<Bookings> GetAllBookings()
        {
            List<Bookings> bookings = new List<Bookings>();
            try
            {
                cmd.CommandText = @"
            SELECT B.BookingID, B.TripID, B.BookingDate, B.Status, 
                   P.PassengerID, P.FirstName as PassengerName, 
                   P.PhoneNumber as PassengerPhoneNumber,
                   R.StartDestination, R.EndDestination,
                   D.DriverName, D.DriverLicense
            FROM Bookings B 
            JOIN Passengers P ON B.PassengerID = P.PassengerID 
            JOIN Trips T ON B.TripID = T.TripID
            JOIN Routes R ON T.RouteID = R.RouteID
            JOIN Driver D ON D.DriverID = T.DriverID";

                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var passenger = new Passengers
                        {
                            PassengersId = (int)reader["PassengerID"],
                            Name = (string)reader["PassengerName"],
                            PhoneNumber = (string)reader["PassengerPhoneNumber"]
                        };
                        var trip = new Trips
                        {
                            TripId = (int)reader["TripID"]
                        };
                        var route = new Routes
                        {
                            StartDestination = (string)reader["StartDestination"],
                            EndDestination = (string)reader["EndDestination"]
                        };
                        var driver = new Driver
                        {
                            DriverName = (string)reader["DriverName"],
                            DriverLicense = (string)reader["DriverLicense"]
                        };
                        var booking = new Bookings
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
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return bookings;
        }
        public void GetAllPassenger()
        {
            try
            {
                cmd.Connection.Open();
                cmd.CommandText = "Select PassengerId,FirstName,PhoneNumber from Passengers where Role = 'User'";
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Exception ex)
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


