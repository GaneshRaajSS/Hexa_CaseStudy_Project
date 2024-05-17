using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Repository
{
    public interface IVehicleRepo
    {
        public List<Vehicles> GetAllVehicles();
        public bool AddVehicle(Vehicles vehicles);
        public bool UpdateVehicle(Vehicles vehicles);
        public bool DeleteVehicle(int vehicleId);
        public List<Vehicles> GetAllAvailableVehicles();


    }
}
