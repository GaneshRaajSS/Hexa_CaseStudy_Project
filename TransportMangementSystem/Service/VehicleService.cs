using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;
using TransportMangementSystem.Exceptions;
using System.Data.SqlClient;

namespace TransportMangementSystem.Service
{
    internal class VehicleService:IVehicleService
    {
        readonly IVehicleRepo _vehicleRepo;
        public VehicleService()
        {
            _vehicleRepo = new VehicleRepo();
        }
        public bool AddVehicle()
        {
            Console.Write("Enter vehicle model: ");
            string model = Console.ReadLine();
            Console.Write("Enter vehicle capacity: ");
            decimal capacity = decimal.Parse(Console.ReadLine());
            Console.Write("Enter vehicle type: ");
            string type = Console.ReadLine();

            Vehicles vehicle = new Vehicles
            {
                VehicleModel = model,
                Capacity = capacity,
                VehicleType = type
            };

            bool addVehicleStatus = _vehicleRepo.AddVehicle(vehicle);
            if (addVehicleStatus)
            {
                Console.WriteLine("Vehicle added Successfully\n");
                DisplayAllVehicles();
            }
            else
            {
                Console.WriteLine("Failed to add vehicle");
            }
            return addVehicleStatus;
        }
        public bool UpdateVehicle()
        {
            DisplayAllVehicles();
            Console.Write("Enter vehicle Id: ");
            int vehicleId = int.Parse(Console.ReadLine());
            Console.Write("Enter vehicle model: ");
            string model = Console.ReadLine();
            Console.Write("Enter vehicle capacity: ");
            decimal capacity = decimal.Parse(Console.ReadLine());
            Console.Write("Enter vehicle type: ");
            string type = Console.ReadLine();
            Console.Write("Enter vehicle status: ");
            string status = Console.ReadLine();

            Vehicles vehicle = new Vehicles
            {
                VehicleId = vehicleId,
                VehicleModel = model,
                Capacity = capacity,
                VehicleType = type,
                Status = status
            };
            bool updateVehicleStatus = _vehicleRepo.UpdateVehicle(vehicle);
            if (updateVehicleStatus)
            {
                Console.WriteLine("Updation successful\n");
            }
            return updateVehicleStatus;
            
        }
        public bool DeleteVehicle()
        {
            DisplayAllVehicles();
            Console.Write("Enter vehicle Id: ");
            int vehicleId = int.Parse(Console.ReadLine());
            bool deleteVehicleStatus = _vehicleRepo.DeleteVehicle(vehicleId);
            if(deleteVehicleStatus)
            {
                Console.WriteLine("Deletion Successful\n");
                DisplayAllVehicles();

            }
            return deleteVehicleStatus;
        }

        public void DisplayAllVehicles()
        {
            List<Vehicles> vehicles = _vehicleRepo.GetAllVehicles();

            Console.WriteLine("All Vehicles:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Vehicle ID: {vehicle.VehicleId}, Model: {vehicle.VehicleModel}, Capacity: {vehicle.Capacity}, Type: {vehicle.VehicleType}, Status: {vehicle.Status}");
            }
        }

        public void DisplayAllAvailVehicles()
        {
            List<Vehicles> vehicles = _vehicleRepo.GetAllAvailableVehicles();

            Console.WriteLine("All Vehicles:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Vehicle ID: {vehicle.VehicleId}, Model: {vehicle.VehicleModel}, Capacity: {vehicle.Capacity}, Type: {vehicle.VehicleType}, Status: {vehicle.Status}");
            }
        }
    }
}
