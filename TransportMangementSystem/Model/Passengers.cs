using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportMangementSystem.Model
{
    public class Passengers
    {
        int passengersId;
        string name;
        string gender;
        int age;
        string email;
        string phoneNumber;

        public int PassengersId
        {
            get { return passengersId; }
            set { passengersId = value;}
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Passengers(int passengersId, string name, string gender, int age, string email, string phoneNumber)
        {
            PassengersId= passengersId;
            Name= name;
            Gender= gender;
            Age= age;
            Email= email;
            PhoneNumber= phoneNumber;
        }
        public Passengers()
        {
            
        }
    }
}
