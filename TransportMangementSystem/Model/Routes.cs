using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportMangementSystem.Model
{
    public class Routes
    {
        int routeId;
        string startDestination;
        string endDestination;
        decimal distance;

        
        public int RouteId {  get { return routeId; } set {  routeId = value; } }
        public string StartDestination { get {  return startDestination; } set {  startDestination = value; } }
        public string EndDestination { get { return endDestination; } set {  endDestination = value; } }
        public decimal Distance { get { return distance; } set {  distance = value; } }

        public Routes()
        {
            
        }

        public Routes(int routeId,string startDestination,string endDestination,decimal distance)
        {
            RouteId = routeId;
            StartDestination = startDestination;
            EndDestination = endDestination;
            Distance = distance;
        }
    }
}
