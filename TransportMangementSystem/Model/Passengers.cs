
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
        string password;
        string role;
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
        }
        public Passengers()
        {
            
        }
        public bool CheckIfUserIsAdmin()
        {
            return Role == "Admin";
        }
    }
}
