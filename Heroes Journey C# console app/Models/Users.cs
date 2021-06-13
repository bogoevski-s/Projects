using System;
using System.Collections.Generic;

namespace Models
{
    public class Users
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }

        public Users()
        {

        }
        public Users(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
        public bool CheckPassword(string pass)
        {
            if(Password == pass)
            {
                return true;
            }
            return false;
        }
    }
}
