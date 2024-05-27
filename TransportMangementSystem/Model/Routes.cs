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
    public class Routes
    {
        int routeId;
        string startDestination;
        string endDestination;
        decimal distance;
<<<<<<< HEAD
        decimal price;

        
        public int RouteId 
        {  
            get { return routeId; } 
            set {  routeId = value; } 
        }
        public string StartDestination 
        { 
            get {  return startDestination; } 
            set {  startDestination = value; } 
        }
        
        public string EndDestination 
        {
            get { return endDestination; } 
            set {  endDestination = value; } 
        }
        public decimal Distance 
        { 
            get { return distance; }
            set {  distance = value; } 
        }
        public decimal Price
        {
            get { return price; } 
            set { price = value; }
        }
=======

        
        public int RouteId {  get { return routeId; } set {  routeId = value; } }
        public string StartDestination { get {  return startDestination; } set {  startDestination = value; } }
        public string EndDestination { get { return endDestination; } set {  endDestination = value; } }
        public decimal Distance { get { return distance; } set {  distance = value; } }
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904

        public Routes()
        {
            
        }

<<<<<<< HEAD
        public Routes(int routeId,string startDestination,string endDestination,decimal distance,decimal price)
=======
        public Routes(int routeId,string startDestination,string endDestination,decimal distance)
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
        {
            RouteId = routeId;
            StartDestination = startDestination;
            EndDestination = endDestination;
            Distance = distance;
<<<<<<< HEAD
            Price = price;
=======
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
        }
    }
}
