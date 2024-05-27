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

namespace TransportMangementSystem.Repository
{
    public interface IDriverRepo
    {
        public bool AllocateDriver(int tripId, int driverId);
        public bool DeallocateDriver(int tripId);
        public List<Driver> AvailableDrivers();
        public void DisplayDetailsForAllocation();
        public List<Driver> AllocatedDriver();
        public void DisplayDetailsForDeAllocation();
    }
}
