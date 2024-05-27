<<<<<<< HEAD
﻿using TransportMangementSystem.Model;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Exception;
using TransportMangementSystem.Model;
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
using TransportMangementSystem.Repository;

namespace TransportMangementSystem.Service
{
    public class Booking_Service : IBookingService
    {
        readonly IBookingRepo _bookingRepo;
        readonly ITripRepo tripRepo;
        public Booking_Service()
        {
            _bookingRepo = new BookingRepo();
            tripRepo = new TripRepo();
        }
<<<<<<< HEAD
        public bool BookTrip(Passengers user)
        {
            if (user.CheckIfUserIsAdmin())
            {
                _bookingRepo.GetAllPassenger();
                Console.WriteLine("Enter Passenger Id: ");
                int passengerId = int.Parse(Console.ReadLine());

                tripRepo.DisplayTrips();
                Console.WriteLine("Enter Trip Id: ");
                int tripId = int.Parse(Console.ReadLine());

                bool bookTripStatus = _bookingRepo.BookTrip(tripId, user,passengerId);
                if (bookTripStatus)
                {
                    Console.WriteLine("Trip booked successfully");
                }
                else
                {
                    Console.WriteLine("Failed to book trip");
                }
                return bookTripStatus;
               
            }
            else
            {
                 tripRepo.DisplayTrips();
                Console.WriteLine("Enter Trip Id: ");
                int tripId = int.Parse(Console.ReadLine());
                int passengerId = user.PassengersId;

                bool bookTripStatus = _bookingRepo.BookTrip(tripId, user, passengerId);
                if (bookTripStatus)
                {
                    Console.WriteLine("Trip booked successfully");
                }
                else
                {
                    Console.WriteLine("Failed to book trip");
                }
                return bookTripStatus;
            }
        }
        public bool CancelBooking(Passengers user)
        {
            if (user.CheckIfUserIsAdmin())
            {
                _bookingRepo.DisplayConfirmedBookings();
                Console.WriteLine("Enter booking Id:");
                int bookingId = int.Parse(Console.ReadLine());
                bool CancelBookingStatus = _bookingRepo.CancelBooking(user.PassengersId, bookingId);
=======
        public bool BookTrip()
        {
            tripRepo.DisplayTrips();
            Console.WriteLine("All Passengers List:");
            _bookingRepo.GetAllPassenger();
            Console.Write("Enter Trip Id: ");
            int tripId = int.Parse(Console.ReadLine());
            Console.Write("Enter Passenger Id: ");
            int passengerId = int.Parse(Console.ReadLine());
            Console.Write("Enter Booking Date (yyyy-MM-dd HH:mm:ss): ");
            DateTime bookingDate = DateTime.Parse(Console.ReadLine());
            bool bookTripStatus = _bookingRepo.BookTrip(tripId, passengerId, bookingDate);
            if (bookTripStatus)
            {
                Console.WriteLine("Trip Booked updated successfully");
            }
            else
            {
                Console.WriteLine("Failed to Trip Booked");
            }
            return bookTripStatus;
        }

        public bool CancelBooking()
        {
                _bookingRepo.DisplayConfirmedBookings();
                Console.WriteLine("Enter booking Id:");
                int bookingId = int.Parse(Console.ReadLine());
                bool CancelBookingStatus = _bookingRepo.CancelBooking(bookingId);
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
                if (CancelBookingStatus)
                {
                    Console.WriteLine("Trip Cancelled successfully");
                }
                else
                {
<<<<<<< HEAD
                    Console.WriteLine("Trip Cancellation Failed.");
                }
                return CancelBookingStatus;
            }
            else
            {
                _bookingRepo.DisplayConfirmedBookings(user.PassengersId);
                Console.WriteLine("Enter booking Id:");
                int bookingId = int.Parse(Console.ReadLine());
                bool CancelBookingStatus = _bookingRepo.CancelBooking(user.PassengersId, bookingId);
                if (CancelBookingStatus)
                {
                    Console.WriteLine("Trip Cancelled successfully");
                }
                else
                {
                    Console.WriteLine("Trip Cancellation Failed.");
                }
                return CancelBookingStatus;
            }
        }

=======
                    Console.WriteLine("Trip Cancellation Falied.");
                }
                return CancelBookingStatus;
          
        }
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
        public void GetBookingsByTrip()
        {
            tripRepo.DisplayTrips();
            Console.WriteLine("Enter Trip Id:");
            int tripId = int.Parse(Console.ReadLine());
            List<Bookings> bookingsForTrip = _bookingRepo.GetBookingsByTrip(tripId);
            DisplayBookings(bookingsForTrip);
        }
<<<<<<< HEAD
        public void GetBookingsByTrip(int userId)
        {
            int tripId = _bookingRepo.GetTripIdByUserId(userId);
            if (tripId != -1)
            {
                List<Bookings> bookingsForTrip = _bookingRepo.GetBookingsByTrip(tripId, userId);
                DisplayBookings(bookingsForTrip);
            }
            else
            {
                Console.WriteLine($"No trip found for the user {userId}.");
            }
        }
        private void DisplayBookings(List<Bookings> bookings)
        {
=======

        private void DisplayBookings(List<Bookings> bookings)
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found for the specified Trip ID.");
                return;
            }
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingId}\n" +
                    $"Trip ID: {booking.Trips.TripId}\n" +
                    $"Booking Date: {booking.BookingDate}\n" +
                    $"Status: {booking.BookingStatus}\n" +
                    $"Passenger Name: {booking.Passengers.Name}\n" +
                    $"Phone Number: {booking.Passengers.PhoneNumber}\n" +
                    $"Source: {booking.Routes.StartDestination}\n" +
                    $"Destination: {booking.Routes.EndDestination}\n");
            }
        }
<<<<<<< HEAD
        public void GetBookingsByPassenger()
=======
        public void getBookingsByPassenger()
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
        {
            _bookingRepo.GetAllPassenger();
            Console.WriteLine("Enter Passenger Id:");
            int passengerId = int.Parse(Console.ReadLine());
<<<<<<< HEAD
            List<Bookings> bookingsForTrip = _bookingRepo.GetBookingsByPassenger(passengerId);
            DisplayBookingsbyPassengers(bookingsForTrip);
        }

        public void GetBookingsByPassenger(Passengers passenger)
        {
            List<Bookings> bookingsForPassenger = _bookingRepo.GetBookingsByPassenger(passenger.PassengersId);
            DisplayBookingsbyPassengers(bookingsForPassenger);
        }

        private void DisplayBookingsbyPassengers(List<Bookings> bookings)
        {
            foreach (var booking in bookings)
            {
                Console.WriteLine($"\nBooking ID: {booking.BookingId}\n" +
=======
            List<Bookings> bookingsForTrip = _bookingRepo.getBookingsByPassenger(passengerId);
            DisplayBookingsbyPassengers(bookingsForTrip);
        }
        private void DisplayBookingsbyPassengers(List<Bookings> bookings)
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found for the specified Passenger ID.");
                return;
            }
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingId}\n" +
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
                    $"Trip ID: {booking.Trips.TripId}\n" +
                    $"Booking Date: {booking.BookingDate}\n" +
                    $"Status: {booking.BookingStatus}\n" +
                    $"Passenger Name: {booking.Passengers.Name}\n" +
                    $"Phone Number: {booking.Passengers.PhoneNumber}\n" +
                    $"Source: {booking.Routes.StartDestination}\n" +
                    $"Destination: {booking.Routes.EndDestination}\n" +
                    $"DriverName: {booking.Driver.DriverName}\n" +
<<<<<<< HEAD
                    $"DriverLicense: {booking.Driver.DriverLicense}\n");
            }
        }

        

=======
                    $"DriverLicense: {booking.Driver.DriverLicense }\n");
            }
        }

>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
    }
}
