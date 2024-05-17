using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Repository
{

    public interface IBookingRepo
    {
        public bool BookTrip(int tripId, int passengerId, DateTime bookingDate);
        public bool MapDriverToVehicle(Driver driver, Vehicles vehicle, Trips trips);
        public bool CancelBooking(int bookingId);
        public void DisplayConfirmedBookings();
        public List<Bookings> GetBookingsByTrip(int tripId);
        public List<Bookings> getBookingsByPassenger(int passengerId);
        public void GetAllPassenger();
    }
}
