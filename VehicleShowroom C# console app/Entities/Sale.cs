using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sale : User
    {
        public int YearsOfExperience { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }
        public int TotalSales { get; set; }
        public Sale(string firstName, string lastName, string mail, string password, RoleEnum role, int experience, DateTime birthDate, string address, int phoneNo, int totalSales) : base(firstName, lastName, mail, password, role)
        {
            YearsOfExperience = experience;
            BirthDate = birthDate;
            Address = address;
            PhoneNo = phoneNo;
            TotalSales = totalSales;
        }
    }
}
