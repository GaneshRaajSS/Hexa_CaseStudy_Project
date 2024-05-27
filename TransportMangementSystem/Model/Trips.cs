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
    public class Trips
    {
        int tripId;
        int vehicleId;
        int routeId;
        DateTime departureDate;
        DateTime arrivalDate;
        string tripStatus;
        string tripType;
        int maxPassengers;
        int? driverId;


        public int TripId {  
            get { return tripId; }
            set { tripId = value; }
        }
        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }
        public int RouteId
        {
            get { return routeId; }
            set { routeId = value; }
        }
        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }
        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }
        public string TripStatus
        {
            get { return tripStatus; }
            set { tripStatus = value; }
        }
        public string TripType
        {
            get { return tripType; }
            set { tripType = value; }
        }
        public int MaxPassengers
        {
            get { return maxPassengers;}
            set { maxPassengers = value;}
        }
        public int? DriverId
        {
            get { return driverId; }
            set { driverId = value; }
        }

        public Trips()
        {
            
        }
        public Trips(int tripId,int vehicleId,int routeId,DateTime departureDate,DateTime arrivalDate,string tripStatus,string tripType,int maxPassengers,int? driverId)
        {
            TripId = tripId;
            VehicleId =vehicleId;
            RouteId = routeId;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            TripStatus = tripStatus;
            TripType = tripType;
            MaxPassengers=maxPassengers;
            DriverId = driverId;
        }
    }
}
