using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Exception;
using TransportMangementSystem.Model;
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
                if (CancelBookingStatus)
                {
                    Console.WriteLine("Trip Cancelled successfully");
                }
                else
                {
                    Console.WriteLine("Trip Cancellation Falied.");
                }
                return CancelBookingStatus;
          
        }
        public void GetBookingsByTrip()
        {
            tripRepo.DisplayTrips();
            Console.WriteLine("Enter Trip Id:");
            int tripId = int.Parse(Console.ReadLine());
            List<Bookings> bookingsForTrip = _bookingRepo.GetBookingsByTrip(tripId);
            DisplayBookings(bookingsForTrip);
        }

        private void DisplayBookings(List<Bookings> bookings)
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found for the specified Trip ID.");
                return;
            }
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
        public void getBookingsByPassenger()
        {
            _bookingRepo.GetAllPassenger();
            Console.WriteLine("Enter Passenger Id:");
            int passengerId = int.Parse(Console.ReadLine());
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
                    $"Trip ID: {booking.Trips.TripId}\n" +
                    $"Booking Date: {booking.BookingDate}\n" +
                    $"Status: {booking.BookingStatus}\n" +
                    $"Passenger Name: {booking.Passengers.Name}\n" +
                    $"Phone Number: {booking.Passengers.PhoneNumber}\n" +
                    $"Source: {booking.Routes.StartDestination}\n" +
                    $"Destination: {booking.Routes.EndDestination}\n" +
                    $"DriverName: {booking.Driver.DriverName}\n" +
                    $"DriverLicense: {booking.Driver.DriverLicense }\n");
            }
        }

    }
}
