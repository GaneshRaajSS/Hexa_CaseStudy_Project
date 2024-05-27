<<<<<<< HEAD
﻿using TransportMangementSystem.Model;

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
=======
﻿using System;
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
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
    }
}
