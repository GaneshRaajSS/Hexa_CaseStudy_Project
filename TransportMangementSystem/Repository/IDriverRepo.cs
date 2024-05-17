using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Repository
{
    public interface IDriverRepo
    {
        public bool AllocateDriver(int tripId, int driverId);
        public bool DeallocateDriver(int tripId);
        public List<Driver> AvailableDrivers();
        public void DisplayDetailsForAllocation();
        public List<Driver> AllocatedDriver();
        public void DisplayDetailsForDeAllocation();
    }
}
