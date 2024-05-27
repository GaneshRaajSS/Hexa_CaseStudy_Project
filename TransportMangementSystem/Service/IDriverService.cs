<<<<<<< HEAD
﻿
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
using TransportMangementSystem.Model;

namespace TransportMangementSystem.Service
{
    public interface IDriverService
    {
        public bool AllocateDriver();
        public bool DeallocateDriver();
        public List<Driver> AvailableDrivers();
        public List<Driver> AllocatedDriver();
    }
}
