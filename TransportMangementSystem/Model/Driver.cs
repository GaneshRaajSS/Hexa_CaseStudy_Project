

namespace TransportMangementSystem.Model
{
    public class Driver
    {
        int driverId;
        string driverName;
        string driverLicense;
        float driverRatings;
        string driverStatus;

        public int DriverId
        {
            get { return driverId; }
            set { driverId = value; }
        }
        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; }
        }
        public string DriverLicense
        {
            get { return driverLicense; }
            set { driverLicense = value; }
        }
        public float DriverRatings
        {
            get { return driverRatings; }
            set { driverRatings = value; }
        }
        public string DriverStatus
        {
            get { return driverStatus; }
            set { driverStatus = value; }
        }
        public Driver()
        {
            
        }
        public Driver(int driverId,string driverName,string driverLicense,float driverRatings,string driverStatus)
        {
            DriverId = driverId;
            DriverName = driverName;
            DriverLicense = driverLicense;
            DriverRatings = driverRatings;
            DriverStatus = driverStatus;
        }
    }
}
