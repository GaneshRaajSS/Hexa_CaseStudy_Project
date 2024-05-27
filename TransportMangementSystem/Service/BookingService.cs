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

        public void GetBookingsByTrip()
        {
            tripRepo.DisplayTrips();
            Console.WriteLine("Enter Trip Id:");
            int tripId = int.Parse(Console.ReadLine());
            List<Bookings> bookingsForTrip = _bookingRepo.GetBookingsByTrip(tripId);
            DisplayBookings(bookingsForTrip);
        }
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
        public void GetBookingsByPassenger()
        {
            _bookingRepo.GetAllPassenger();
            Console.WriteLine("Enter Passenger Id:");
            int passengerId = int.Parse(Console.ReadLine());
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
                    $"Trip ID: {booking.Trips.TripId}\n" +
                    $"Booking Date: {booking.BookingDate}\n" +
                    $"Status: {booking.BookingStatus}\n" +
                    $"Passenger Name: {booking.Passengers.Name}\n" +
                    $"Phone Number: {booking.Passengers.PhoneNumber}\n" +
                    $"Source: {booking.Routes.StartDestination}\n" +
                    $"Destination: {booking.Routes.EndDestination}\n" +
                    $"DriverName: {booking.Driver.DriverName}\n" +
                    $"DriverLicense: {booking.Driver.DriverLicense}\n");
            }
        }

        

    }
}
