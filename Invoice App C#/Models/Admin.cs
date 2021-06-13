using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin : User
    {
        public CompanyEnum Company { get; set; }

        public Admin(string userName, string email, string password, RoleEnum role, CompanyEnum company) : base(userName, email, password, role)
        {
            Company = company;
        }
        public void AdminInvoices(List<Invoice> invoicesList)
        {
            foreach (Invoice invoice in invoicesList)
            {
                if(invoice.Company == Company)
                {
                    if(invoice.Payed == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(invoice.InvoiceInfo());
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(invoice.InvoiceInfo());
                        Console.ResetColor();
                    } 
                }
            }
        }
    }
}
