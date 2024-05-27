<<<<<<< HEAD
﻿
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
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
<<<<<<< HEAD

            int scheduledTripId = tripRepo.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate, maxPassengers);
            if (scheduledTripId <= 0)
            {
                Console.WriteLine("Failed to schedule trip.");
                return false;
            }
            else
            {
                Console.WriteLine("Trip scheduled successfully. Details:");
                tripRepo.DisplayScheduledTripDetails(scheduledTripId);
                Console.WriteLine("Please allocate a Driver.");
                return true;
            }
=======
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
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
        }

        public bool CancelTrip()
        {
<<<<<<< HEAD
            tripRepo.DisplayTripsForCancelation();
=======
            tripRepo.DisplayTrips();
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
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
