
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
