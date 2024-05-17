using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportMangementSystem.Repository
{
    public interface ITripRepo
    {
        public bool ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate,int maxPassengers);

        public bool CancelTrip(int tripId);
        public void DisplayRoutes();
        public void DisplayTrips();
    }
}
