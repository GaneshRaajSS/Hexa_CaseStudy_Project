using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Service
{
    public interface IDriverService
    {
        public bool AllocateDriver();
        public bool DeallocateDriver();
        public List<Driver> AvailableDrivers();
        public List<Driver> AllocatedDriver();
    }
}
