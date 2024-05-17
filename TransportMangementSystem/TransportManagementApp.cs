using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;
using TransportMangementSystem.Service;

namespace TransportMangementSystem
{
    public class TransportManagementApp
    {
        readonly IVehicleService _ivehicleService;
        readonly ITripService _itripService;
        readonly IBookingService _bookingService;
        readonly IDriverService _driverService;

        public TransportManagementApp()
        {
            _ivehicleService = new VehicleService();
            _itripService = new TripService();
            _bookingService = new Booking_Service();
            _driverService = new DriverService();
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to transport System!");
            Console.WriteLine("1.Vehicle Management");
            Console.WriteLine("2.Trip Management");
            Console.WriteLine("3.Booking Management");
            Console.WriteLine("4.Driver Allocation");
            Console.WriteLine("5.Booking Retrieval");
            Console.WriteLine("6.Exit");
            Console.Write("Select an Option: ");
            int userOption = int.Parse(Console.ReadLine());

            switch (userOption)
            {
                case 1:
                    Console.WriteLine("1.Add Vehicle");
                    Console.WriteLine("2.Update Vehicle");
                    Console.WriteLine("3.Delete Vehicle");
                    Console.WriteLine("4.Go Back");
                    Console.Write("Enter Vehicle Option: ");
                    int vehicleOption = int.Parse(Console.ReadLine());
                    switch (vehicleOption)
                    {
                        case 1:
                            _ivehicleService.AddVehicle();
                            AskToContinue();
                            break;
                        case 2:
                            _ivehicleService.UpdateVehicle();
                            AskToContinue();
                            break;
                        case 3:
                            _ivehicleService.DeleteVehicle();
                            AskToContinue();
                            break;
                        case 4:
                            Menu();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("1.Schedule Trip");
                    Console.WriteLine("2.Cancel Trip");
                    Console.WriteLine("3.Go Back");
                    Console.Write("Enter Schedule Option: ");
                    int tripOption = int.Parse(Console.ReadLine());
                    switch (tripOption)
                    {
                        case 1:
                            _itripService.ScheduleTrip();
                            AskToContinue();
                            break;
                        case 2:
                            _itripService.CancelTrip();
                            AskToContinue();
                            break;
                        case 3:
                            Menu();
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("1.Book Trip");
                    Console.WriteLine("2.Cancel Booking");
                    Console.WriteLine("3.Go Back");
                    Console.Write("Enter Book Option: ");
                    int bookOption = int.Parse(Console.ReadLine());
                    switch (bookOption)
                    {
                        case 1:
                            _bookingService.BookTrip();
                            AskToContinue();
                            break;
                        case 2:
                            _bookingService.CancelBooking();
                            AskToContinue();
                            break;
                        case 3:
                            Menu();
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("1.Driver Allocation");
                    Console.WriteLine("2.Driver Deallocation");
                    Console.WriteLine("3.Available Drivers");
                    Console.WriteLine("4.Go Back");
                    Console.Write("Enter Drivers Option: ");
                    int driverOption = int.Parse(Console.ReadLine());
                    switch (driverOption)
                    {
                        case 1:
                            _driverService.AllocateDriver();
                            AskToContinue();
                            break;
                        case 2:
                            _driverService.DeallocateDriver();
                            AskToContinue();
                            break;
                        case 3:
                            _driverService.AvailableDrivers();
                            AskToContinue();
                            break;
                        case 4:
                            Menu();
                            break;
                    }
                    break;
                case 5:
                    Console.WriteLine("1.GetBookingsByPassenger");
                    Console.WriteLine("2.GetBookingsByTrip");
                    Console.WriteLine("3.Go Back");
                    Console.Write("Enter Retrieval Option: ");
                    int retrievalOption = int.Parse(Console.ReadLine());
                    switch (retrievalOption)
                    {
                        case 1:
                            _bookingService.getBookingsByPassenger();
                            AskToContinue();
                            break;
                        case 2:
                            _bookingService.GetBookingsByTrip();
                            AskToContinue();
                            break;
                        case 3:
                            Menu();
                            break;
                    }

                    break;

            }
            void AskToContinue()
            {
                Console.WriteLine("Do you want to continue: Yes?No");
                string conOption = Console.ReadLine();
                if(conOption.ToLower() == "yes")
                {
                    Menu();
                }
                else
                {
                    Console.WriteLine("Thank you for using.");
                }
            }
        }
        
    }
}
