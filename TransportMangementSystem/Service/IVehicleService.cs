<<<<<<< HEAD
﻿
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
    public interface IVehicleService
    {
        public void DisplayAllVehicles();
        public bool AddVehicle();
        public bool UpdateVehicle();
        public bool DeleteVehicle();
        public void DisplayAllAvailVehicles();
    }
}
