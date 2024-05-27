

namespace TransportMangementSystem.Model
{
    public class Bookings
    {
        int bookingId;
        Trips trips;
        Routes routes;
        DateTime bookingDate;
        string bookingStatus;
        Passengers passengers;
        Driver driver;

        public int BookingId
        {
            get { return bookingId; }
            set { bookingId = value; }
        }
        public Trips Trips
        {
            get { return trips; }
            set { trips = value; }
        }
        public Routes Routes
        {
            get { return routes; }
            set { routes = value; }
        }

        public DateTime BookingDate
        {
            get { return bookingDate; }
            set { bookingDate = value; }
        }
        public string BookingStatus
        {
            get { return bookingStatus; }
            set { bookingStatus = value; }
        }
        public Passengers Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }
        public Driver Driver
        {
            get { return driver; }
            set {  driver = value; }
        }
        public Bookings()
        {
        }

        public Bookings(int bookingId, Trips trips, Routes routes, DateTime bookingDate, string bookingStatus, Passengers passengers,Driver driver)
        {
            BookingId = bookingId;
            Trips = trips;
            Routes = routes;
            BookingDate = bookingDate;
            BookingStatus = bookingStatus;
            Passengers = passengers;
            Driver = driver;
        }
    }
}
