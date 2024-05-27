
namespace TransportMangementSystem.Repository
{
    public interface ITripRepo
    {
        public int ScheduleTrip(int vehicleId, int routeId, DateTime departureDate, DateTime arrivalDate, int maxPassengers);
        public bool CancelTrip(int tripId);
        public void DisplayRoutes();
        public void DisplayTrips();
        public void DisplayScheduledTripDetails(int tripId);
        public void DisplayTripsForCancelation();
    }
}
