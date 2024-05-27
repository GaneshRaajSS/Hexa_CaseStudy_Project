<<<<<<< HEAD
﻿using TransportMangementSystem.Model;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportMangementSystem.Model;
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904

namespace TransportMangementSystem.Service
{
    public interface IBookingService
    {
<<<<<<< HEAD
        public bool BookTrip(Passengers user);
        public bool CancelBooking(Passengers user);
        public void GetBookingsByTrip();
        public void GetBookingsByTrip(int userId);
        public void GetBookingsByPassenger();
        public void GetBookingsByPassenger(Passengers passenger);
=======
        public bool BookTrip();
        public bool CancelBooking();
        public void GetBookingsByTrip();
        public void getBookingsByPassenger();

>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
    }
}
