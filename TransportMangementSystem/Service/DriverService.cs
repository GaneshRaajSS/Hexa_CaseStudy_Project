using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;

namespace TransportMangementSystem.Service
{
    public class DriverService : IDriverService
    {
        readonly IDriverRepo _driverRepo;
        readonly ITripRepo _tripRepo;
        public DriverService()
        {
            _driverRepo = new DriverRepo();
            _tripRepo = new TripRepo();
        }

        public List<Driver> AllocatedDriver()
        {
            List<Driver> allocatedDrivers = _driverRepo.AllocatedDriver();
            Console.WriteLine("All Allocated Drivers:");
            foreach (var drivers in allocatedDrivers)
            {
                Console.WriteLine($"Driver ID: {drivers.DriverId}, Driver Name: {drivers.DriverName}, Driver license: {drivers.DriverLicense}, Driver Rating: {drivers.DriverRatings}, Status: {drivers.DriverStatus}");
            }
            return allocatedDrivers;
        }

        public bool AllocateDriver()
        {
            AvailableDrivers();
            _driverRepo.DisplayDetailsForAllocation();
            Console.WriteLine("Enter Driver ID: ");
            int driverId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Trip ID: ");
            int tripId = int.Parse(Console.ReadLine());
            bool AllocateDriverStatus = _driverRepo.AllocateDriver(tripId, driverId);
            if(AllocateDriverStatus )
            {
                Console.WriteLine("Driver Allocated Successfully.");
            }
            else{
                Console.WriteLine("Driver Allocation Failed.");
            }
            return AllocateDriverStatus;
        }

        public List<Driver> AvailableDrivers()
        {
            List<Driver> availableDrivers = _driverRepo.AvailableDrivers();
            Console.WriteLine("All Available Drivers:");
            foreach (var drivers in availableDrivers)
            {
                Console.WriteLine($"Driver ID: {drivers.DriverId}, Driver Name: {drivers.DriverName}, Driver license: {drivers.DriverLicense}, Driver Rating: {drivers.DriverRatings}, Status: {drivers.DriverStatus}");
            }
            return availableDrivers;
        }

        public bool DeallocateDriver()
        {
            AllocatedDriver();
            _driverRepo.DisplayDetailsForDeAllocation();
            Console.WriteLine("Enter Trip ID: ");
            int tripId = int.Parse(Console.ReadLine());
            bool DeallocateDriverStatus = _driverRepo.DeallocateDriver(tripId);
            if (DeallocateDriverStatus)
            {
                Console.WriteLine("Driver Deallocated Successfully.");
            }
            else
            {
                Console.WriteLine("Driver Deallocation Failed.");
            }
            return DeallocateDriverStatus;
        }
    }
}
