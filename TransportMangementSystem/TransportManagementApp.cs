using TransportMangementSystem.Model;
using TransportMangementSystem.Service;

namespace TransportMangementSystem
{
    public class TransportManagementApp
    {
        readonly IVehicleService _ivehicleService;
        readonly ITripService _itripService;
        readonly IBookingService _bookingService;
        readonly IDriverService _driverService;
        readonly IPassengersSerivce _passengersSerivce;

        public TransportManagementApp()
        {
            _ivehicleService = new VehicleService();
            _itripService = new TripService();
            _bookingService = new Booking_Service();
            _driverService = new DriverService();
            _passengersSerivce = new PassengersSerivce();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                int loginOption = int.Parse(Console.ReadLine());

                switch (loginOption)
                {
                    case 1:
                        Passengers user = _passengersSerivce.LoginPassenger();
                        if (user != null)
                        {
                            if (user.Role == "Admin")
                            {
                                AdminMenu(user);
                            }
                            else if (user.Role == "User")
                            {
                                UserMenu(user);
                            }
                        }
                        break;
                    case 2:
                        _passengersSerivce.RegisterPassenger();
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void AdminMenu(Passengers user)
        {
            while (true)
            {
                Console.WriteLine($"                                    Welcome to Transport Management System\n");
                Console.Write("Welcome\t");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{user.Name}\n",Console.ForegroundColor);
                Console.ResetColor();
                Console.WriteLine("\n1. Vehicle Management");
                Console.WriteLine("2. Trip Management");
                Console.WriteLine("3. Booking Management");
                Console.WriteLine("4. Driver Allocation");
                Console.WriteLine("5. Booking Retrieval");
                Console.WriteLine("6. Exit");
                Console.Write("Select an Option: ");
                int userOption = int.Parse(Console.ReadLine());

                switch (userOption)
                {
                    case 1:
                        VehicleManagementMenu();
                        break;
                    case 2:
                        TripManagementMenu();
                        break;
                    case 3:
                        BookingManagementMenu(user);
                        break;
                    case 4:
                        DriverAllocationMenu();
                        break;
                    case 5:
                        BookingRetrievalMenu();
                        break;
                    case 6:
                        return;
                }
            }
        }

        private void VehicleManagementMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Vehicle");
                Console.WriteLine("2. Update Vehicle");
                Console.WriteLine("3. Delete Vehicle");
                Console.WriteLine("4. Go Back");
                Console.Write("Enter Vehicle Option: ");
                int vehicleOption = int.Parse(Console.ReadLine());
                switch (vehicleOption)
                {
                    case 1:
                        _ivehicleService.AddVehicle();
                        break;
                    case 2:
                        _ivehicleService.UpdateVehicle();
                        break;
                    case 3:
                        _ivehicleService.DeleteVehicle();
                        break;
                    case 4:
                        return;
                        
                }
            }
        }

        private void TripManagementMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Schedule Trip");
                Console.WriteLine("2. Cancel Trip");
                Console.WriteLine("3. Go Back");
                Console.Write("Enter Schedule Option: ");
                int tripOption = int.Parse(Console.ReadLine());
                switch (tripOption)
                {
                    case 1:
                        _itripService.ScheduleTrip();
                        break;
                    case 2:
                        _itripService.CancelTrip();
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void BookingManagementMenu(Passengers user)
        {
            while (true)
            {
                Console.WriteLine("\n1. Book Trip");
                Console.WriteLine("2. Cancel Booking");
                Console.WriteLine("3. Go Back");
                Console.Write("Enter Book Option: ");
                int bookOption = int.Parse(Console.ReadLine());
                switch (bookOption)
                {
                    case 1:
                        _bookingService.BookTrip(user);
                        break;
                    case 2:
                        _bookingService.CancelBooking(user);
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void DriverAllocationMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Driver Allocation");
                Console.WriteLine("2. Driver Deallocation");
                Console.WriteLine("3. Available Drivers");
                Console.WriteLine("4. Go Back");
                Console.Write("Enter Drivers Option: ");
                int driverOption = int.Parse(Console.ReadLine());
                switch (driverOption)
                {
                    case 1:
                        _driverService.AllocateDriver();
                        break;
                    case 2:
                        _driverService.DeallocateDriver();
                        break;
                    case 3:
                        _driverService.AvailableDrivers();
                        break;
                    case 4:
                        return;
                }
            }
        }

        private void BookingRetrievalMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. GetBookingsByPassenger");
                Console.WriteLine("2. GetBookingsByTrip");
                Console.WriteLine("3. Go Back");
                Console.Write("Enter Retrieval Option: ");
                int retrievalOption = int.Parse(Console.ReadLine());
                switch (retrievalOption)
                {
                    case 1:
                        _bookingService.GetBookingsByPassenger();
                        break;
                    case 2:
                        _bookingService.GetBookingsByTrip();
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void UserMenu(Passengers user)
        {
            while (true)
            {
                Console.WriteLine($"                                    Welcome to Transport Management System\n");
                Console.Write("Welcome\t");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{user.Name}\n", Console.ForegroundColor);
                Console.ResetColor();
                Console.WriteLine("1. Trip Management");
                Console.WriteLine("2. Booking Management");
                Console.WriteLine("3. Booking Retrieval");
                Console.WriteLine("4. Exit");
                Console.Write("Select an Option: ");
                int userOption = int.Parse(Console.ReadLine());

                switch (userOption)
                {
                    case 1:
                        UserTripManagementMenu();
                        break;
                    case 2:
                        UserBookingManagementMenu(user);
                        break;
                    case 3:
                        UserBookingRetrievalMenu(user);
                        break;
                    case 4:
                        return;
                }
            }
        }

        private void UserTripManagementMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Schedule Trip");
                Console.WriteLine("2. Cancel Trip");
                Console.WriteLine("3. Go Back");
                Console.Write("Enter Schedule Option: ");
                int tripOption = int.Parse(Console.ReadLine());
                switch (tripOption)
                {
                    case 1:
                        _itripService.ScheduleTrip();
                        break;
                    case 2:
                        _itripService.CancelTrip();
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void UserBookingManagementMenu(Passengers user)
        {
            while (true)
            {
                Console.WriteLine("1. Book Trip");
                Console.WriteLine("2. Cancel Booking");
                Console.WriteLine("3. Go Back");
                Console.Write("Enter Book Option: ");
                int bookOption = int.Parse(Console.ReadLine());
                switch (bookOption)
                {
                    case 1:
                        _bookingService.BookTrip(user);
                        break;
                    case 2:
                        _bookingService.CancelBooking(user);
                        break;
                    case 3:
                        return;
                }
            }
        }

        private void UserBookingRetrievalMenu(Passengers user)
        {
            while (true)
            {
                Console.WriteLine("1. GetBookingsByPassenger");
                Console.WriteLine("2. GetBookingsByTrip");
                Console.WriteLine("3. Go Back");
                Console.Write("Enter Retrieval Option: ");
                int retrievalOption = int.Parse(Console.ReadLine());
                switch (retrievalOption)
                {
                    case 1:
                        _bookingService.GetBookingsByPassenger(user);
                        break ;
                    case 2:
                        _bookingService.GetBookingsByTrip(user.PassengersId);
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}

