
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Service
{
    internal interface IPassengersSerivce
    {
        public Passengers LoginPassenger();
        bool RegisterPassenger();
    }
}
