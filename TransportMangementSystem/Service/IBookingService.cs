using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Service
{
    public interface IBookingService
    {
        public bool BookTrip();
        public bool CancelBooking();
        public void GetBookingsByTrip();
        public void getBookingsByPassenger();

    }
}
