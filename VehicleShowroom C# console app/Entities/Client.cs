using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Entities
{
    public class Client : User 
    {
        public int Balance { get; set; }
        public Client(string firstName, string lastName, string mail, string password, RoleEnum role, int balance) : base (firstName, lastName, mail, password, role)
        {
            Balance = balance;
        }
    }
}
