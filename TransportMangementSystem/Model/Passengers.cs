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
    public class Passengers
    {
        int passengersId;
        string name;
        string gender;
        int age;
        string email;
        string phoneNumber;
<<<<<<< HEAD
        string password;
        string role;
=======

>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
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
<<<<<<< HEAD
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public Passengers(int passengersId, string name, string gender, int age, string email, string phoneNumber, string password, string role)
        {
            PassengersId = passengersId;
            Name = name;
            Gender = gender;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
=======

        public Passengers(int passengersId, string name, string gender, int age, string email, string phoneNumber)
        {
            PassengersId= passengersId;
            Name= name;
            Gender= gender;
            Age= age;
            Email= email;
            PhoneNumber= phoneNumber;
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
        }
        public Passengers()
        {
            
        }
<<<<<<< HEAD
        public bool CheckIfUserIsAdmin()
        {
            return Role == "Admin";
        }
=======
>>>>>>> 8a098114f76984c37ce76a6374a74183846fd904
    }
}
