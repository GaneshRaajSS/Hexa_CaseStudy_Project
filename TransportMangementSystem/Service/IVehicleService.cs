using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Service
{
    public interface IVehicleService
    {
        public void DisplayAllVehicles();
        public bool AddVehicle();
        public bool UpdateVehicle();
        public bool DeleteVehicle();
        public void DisplayAllAvailVehicles();
    }
}
