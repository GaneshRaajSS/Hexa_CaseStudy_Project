
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Repository
{
    internal interface IPassengersRepo
    {
        public int RegisterPassenger(Passengers passenger);
        public Passengers LoginPassenger(int id, string password);
        public Passengers GetPassengerById(int id);
    }
}
