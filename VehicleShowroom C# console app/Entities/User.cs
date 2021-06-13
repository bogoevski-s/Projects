using Enums;
using System;

namespace Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Mail { get; set; }
        private string Password { get; set; }
        public RoleEnum Role { get; set; }


        public User(string firstName, string lastName, string mail, string password, RoleEnum role)
        {
            Id = new Random().Next(10, 100) + new Random().Next(10, 1000);
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
            Password = password;
            Role = role;
        }
        public bool PasswordCheck(string pass)
        {
            if (Password != pass)
            {
                return false;
            }

            return true;
        }
    }
}
