using TransportMangementSystem.Model;

namespace TransportMangementSystem.Repository
{
    public interface IBookingRepo
    {
        public bool BookTrip(int tripId, Passengers user, int passengerId);
        public bool CancelBooking(int userId, int bookingId);
        public void DisplayConfirmedBookings();
        public void DisplayConfirmedBookings(int userId);
        public List<Bookings> GetBookingsByTrip(int tripId, int userId);
        public List<Bookings> GetBookingsByTrip(int tripId);
        public List<Bookings> GetAllBookings();
        public List<Bookings> GetBookingsByPassenger(int passengerId);
        public void GetAllPassenger();


        public void DisplayTrips();
        public int GetTripIdByUserId(int userId);
    }
}
