using TransportMangementSystem.Model;

namespace TransportMangementSystem.Service
{
    public interface IBookingService
    {
        public bool BookTrip(Passengers user);
        public bool CancelBooking(Passengers user);
        public void GetBookingsByTrip();
        public void GetBookingsByTrip(int userId);
        public void GetBookingsByPassenger();
        public void GetBookingsByPassenger(Passengers passenger);
    }
}
