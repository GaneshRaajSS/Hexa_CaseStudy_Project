using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportMangementSystem.Exceptions
{
    public class VehcileNotFoundException:ApplicationException
    {
        public VehcileNotFoundException()
        {
            
        }
        public VehcileNotFoundException(string message) : base(message) { }
    }
}
