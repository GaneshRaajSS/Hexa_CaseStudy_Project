using System.Reflection;
using TransportMangementSystem.Exception;
using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;

namespace TransportMangementSystem.Tests
{
    public class Tests
    {
        BookingRepo bookingRepo = new BookingRepo();
        [Test]
        public void Test_Booking_Successful()
        {
            
            int tripId = 213;
            int passengerId = 303;
            DateTime bookingDate = DateTime.Now;
            bool bookingResult = bookingRepo.BookTrip(tripId, passengerId, bookingDate);
            Assert.IsTrue(bookingResult, "Booking should be successful");
        }

        [Test]
        public void Test_Map_Driver_To_Vehicle()
        {
            Driver driver = new Driver { DriverId = 500 };
            Vehicles vehicle = new Vehicles { VehicleId = 1 };
            Trips trips = new Trips { TripId = 200, DriverId = 500, VehicleId = 1 };
            bool mappingResult = bookingRepo.MapDriverToVehicle(driver, vehicle, trips);
            Assert.IsTrue(mappingResult, "Driver mapping successful");
        }
    }
}