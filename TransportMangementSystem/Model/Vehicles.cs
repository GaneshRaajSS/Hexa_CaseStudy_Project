<<<<<<< HEAD
﻿
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
namespace TransportMangementSystem.Model
{
    public class Vehicles
    {
        int vehicleId;
        string vehicleModel;
        decimal capacity;
        string vehicleType;
        string status;

        public int VehicleId
        {
            get{ return vehicleId; }
            set { vehicleId = value; }
        }
        public string VehicleModel
        {
            get {  return vehicleModel; }
            set { vehicleModel = value; }
        }
        public decimal Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public Vehicles()
        { }

        public Vehicles(int vehicleId, string vehicleModel, decimal capacity, string vehicleType, string status)
        {
            VehicleId = vehicleId;
            VehicleModel = vehicleModel;
            Capacity = capacity;
            VehicleType = vehicleType;
            Status = status;
        }

    }
}
