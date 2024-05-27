<<<<<<< HEAD
﻿
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
namespace TransportMangementSystem.Repository
{
    public interface ITripRepo
    {
<<<<<<< HEAD
        public int ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate, int maxPassengers);
        public bool CancelTrip(int tripId);
        public void DisplayRoutes();
        public void DisplayTrips();
        public void DisplayScheduledTripDetails(int tripId);
        public void DisplayTripsForCancelation();
=======
        public bool ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate,int maxPassengers);

        public bool CancelTrip(int tripId);
        public void DisplayRoutes();
        public void DisplayTrips();
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
    }
}
