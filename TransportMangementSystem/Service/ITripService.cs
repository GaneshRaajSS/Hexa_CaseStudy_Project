using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportMangementSystem.Service
{
    internal interface ITripService
    {
        public bool ScheduleTrip();
        public bool CancelTrip();
    }
}
