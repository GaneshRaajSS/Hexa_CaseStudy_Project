using TransportMangementSystem.Model;
using TransportMangementSystem.Repository;
using TransportMangementSystem.Service;

namespace TransportMangementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransportManagementApp transportManagementApp = new TransportManagementApp();
            transportManagementApp.Menu();
        }
    }
}
