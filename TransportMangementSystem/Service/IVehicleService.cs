
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
