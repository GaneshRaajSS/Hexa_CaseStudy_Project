using System.Reflection;
using TransportMangementSystem.Exception;
using TransportMangementSystem.Exceptions;
using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;
using TransportMangementSystem.Service;

namespace TicketMangementSystem.Tests
{
    public class Tests
    {
        BookingRepo bookingRepo = new BookingRepo();
        VehicleRepo vehicleRepo = new VehicleRepo();
        DriverRepo driverRepo = new DriverRepo();

        //[Test]
        //public void Test_Booking_Successful()
        //{
        //    int tripId = 290;
        //    Passengers user = new Passengers
        //    {
        //        Role = "Admin"
        //    };
        //    int passengerId = 34;
        //    bool bookingResult = bookingRepo.BookTrip(tripId, user, passengerId);
        //    //Assert.IsTrue(bookingResult, "Booking should be successful");
        //    Assert.That(bookingResult, Is.True);
        //}

        [Test]
        public void Test_Map_Driver_To_Vehicle()
        {
            Driver driver = new Driver { DriverId = 506 };
            Vehicles vehicle = new Vehicles { VehicleId = 12 };
            Trips trips = new Trips { TripId = 226, DriverId = 506, VehicleId = 12 };
            bool mappingResult = bookingRepo.MapDriverToVehicle(driver, vehicle, trips);
            Assert.That(mappingResult,Is.True);
        }

        //[Test]
        //public void Test_To_Add_Vehicle()
        //{
        //    Vehicles vehicles = new Vehicles
        //    {
        //        VehicleModel = "Tata Nixon",
        //        Capacity = 16.57M,
        //        VehicleType = "Car",
        //        Status = "Available"
        //    };
        //    bool vehicleResult = vehicleRepo.AddVehicle(vehicles);
        //    Assert.IsTrue(vehicleResult, "Vehicle adding successful ");
        //}

        //[Test]
        //public void Test_To_Get_Available_Drivers()
        //{
        //    List<Driver> availDrivers = driverRepo.AvailableDrivers();
        //    Assert.IsNotNull(availDrivers);
        //    //Assert.IsTrue(availDrivers.Count()>0);
        //}

        //[Test]
        //public void Test_Booking_Not_Found()
        //{
        //    int passengerId = 304;
        //    Assert.Throws<BookingNotFoundException>(() =>
        //    {
        //        var result = bookingRepo.GetBookingsByPassenger(passengerId);
        //    });
        //}

        //[Test]
        //public void Test_To_Vehicle_Not_Found()
        //{
        //    int vehicleId = 1000;
        //    Assert.Throws<VehcileNotFoundException>(() =>
        //    {
        //        vehicleRepo.DeleteVehicle(vehicleId);

        //    });
        //}
    }
}