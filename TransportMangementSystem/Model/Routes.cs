
namespace TransportMangementSystem.Model
{
    public class Routes
    {
        int routeId;
        string startDestination;
        string endDestination;
        decimal distance;
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

        public Routes()
        {
            
        }

        public Routes(int routeId,string startDestination,string endDestination,decimal distance,decimal price)
        {
            RouteId = routeId;
            StartDestination = startDestination;
            EndDestination = endDestination;
            Distance = distance;
            Price = price;
        }
    }
}
