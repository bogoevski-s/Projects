using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : User
    {
        private int Balance { get; set; }
        public List<Invoice> InvoicesList { get; set; }
        public Client(string userName, string email, string password, int balance, RoleEnum role) : base (userName, email, password, role)
        {
            Balance = balance;
            InvoicesList = new List<Invoice>();
        }

        public int CheckBalance()
        {
            return Balance;
        }

        public int AddBalance(int amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong input\nCant add negative numbers or characters. Please try again"); 
            }
            return Balance;
        }

        public int PayInvoice(int invoiceNum)
        {
            Invoice invoicePay = InvoicesList.FirstOrDefault(x => x.InvocieNumber == invoiceNum);
            if(invoicePay == null)
            {
                throw new Exception("Invoice number not found!!! Try again later");
            }
            if (invoicePay.Payed == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nInvoice already paid\n");
                Console.ResetColor();
            }
            else if(Balance >= invoicePay.Amount)
            {
                Console.Clear();
                Balance -= invoicePay.Amount;
                invoicePay.Payed = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccessful paymet\n");
                Console.ResetColor();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nNot enough money\n");
                Console.ResetColor();
            }
            
            return Balance;
        }

        public void AllInvoices()
        {
            foreach (Invoice invoices in InvoicesList)
            {
                if(invoices.Payed == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(invoices.InvoiceInfo());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(invoices.InvoiceInfo());
                    invoices.PenaltyPayment();
                }
            }
        }
    }
}
