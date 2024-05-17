using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;

namespace TransportMangementSystem.Service
{
    public class TripService:ITripService
    {
        readonly ITripRepo tripRepo;
        readonly IVehicleService vehicleService;
        public TripService()
        {
            vehicleService = new VehicleService();
            tripRepo = new TripRepo();
        }
        public bool ScheduleTrip()
        {
            vehicleService.DisplayAllAvailVehicles();
            tripRepo.DisplayRoutes();
            Console.Write("Enter vehicle Id: ");
            int vehicleId = int.Parse(Console.ReadLine());
            Console.Write("Enter Route Id: ");
            int routeId = int.Parse(Console.ReadLine());
            Console.Write("Enter departure date (yyyy-MM-dd HH:mm:ss): ");
            DateTime departureDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter arrival date (yyyy-MM-dd HH:mm:ss): ");
            DateTime arrivalDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Max Passengers:");
            int maxPassengers = int.Parse(Console.ReadLine());
            bool scheduleTripStatus = tripRepo.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate,maxPassengers);
            if (scheduleTripStatus)
            {
                Console.WriteLine("Trip scheduled successfully.Please allocate Driver.");
            }
            else
            {
                Console.WriteLine("Failed to schedule trip.");
            }
            return scheduleTripStatus;
        }

        public bool CancelTrip()
        {
            tripRepo.DisplayTrips();
            Console.Write("Enter Trip ID:");
            int tripId = int.Parse(Console.ReadLine());
            bool cancelTripStatus = tripRepo.CancelTrip(tripId);
            if (cancelTripStatus)
            {
                Console.WriteLine("Trip cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Failed to cancel trip.");
            }
            return cancelTripStatus;
        }
    }
}
