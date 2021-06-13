using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class DbUsers
    {
        public static List<User> Users;

        static DbUsers()
        {
            Users = new List<User>
            {
                new Client("Slave", "Bogoevski", "slave@gmail.com", "123", Enums.RoleEnum.Client, 15000),
                new Sale("Risto", "Pancevski", "risto@gmail.com", "123", Enums.RoleEnum.Sale, 7, new DateTime(1989, 06, 15), "Street Blv", 075555333, 80),
                new Merchant("Bob", "Bobsky", "bob@gmail.com", "123", Enums.RoleEnum.Merchant, 10, new DateTime(1985, 10, 10), "Partizanska", 070111222, 120),
                new Client("Sam", "Samsky", "sam@gmail.com", "sam123", Enums.RoleEnum.Client, 55000),
                new Sale("Robert", "Denirio", "rob@gmail.com", "robert123", Enums.RoleEnum.Sale, 5, new DateTime(1990, 01, 25), "Las Vegas Street Blv", 075999123, 50),
                new Merchant("Jim", "Kersky", "jim@gmail.com", "jim123", Enums.RoleEnum.Merchant, 8, new DateTime(1987, 07, 19), "Partizanska", 070121222, 220)

            };
        }
    }
}
