
using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;

namespace TransportMangementSystem.Service
{
    internal class PassengersSerivce : IPassengersSerivce
    {
        readonly IPassengersRepo passengersRepo;
        public PassengersSerivce()
        {
            passengersRepo = new PassengersRepo();
        }


        public bool RegisterPassenger()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter phone number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            Passengers passenger = new Passengers
            {
                Name = name,
                Gender = gender,
                Age = age,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password
            };

            int newPassengerId = passengersRepo.RegisterPassenger(passenger);
            if (newPassengerId > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRegistration successful. Fetching details...\n",Console.ForegroundColor);
                Console.ResetColor();

                Passengers registeredPassenger = passengersRepo.GetPassengerById(newPassengerId);
                if (registeredPassenger != null)
                {
                    Console.WriteLine($"Passenger ID: {registeredPassenger.PassengersId}\t\t" +
                        $"Name: {registeredPassenger.Name} Gender: {registeredPassenger.Gender}\t\t" +
                        $"Age: {registeredPassenger.Age}\t\t " +
                        $"Email: {registeredPassenger.Email}\t\t" +
                        $"Phone Number: {registeredPassenger.PhoneNumber}\n");
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to retrieve passenger details.",Console.ForegroundColor);
                    Console.ResetColor();
                    return false;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Registration failed.", Console.ForegroundColor);
                Console.ResetColor();
                return false;
            }
        }
        public Passengers LoginPassenger()
        {
            Console.WriteLine("Enter ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            Passengers user = passengersRepo.LoginPassenger(id, password);


            return user;
        }

    }
}
