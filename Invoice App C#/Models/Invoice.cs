using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Invoice
    {

        public CompanyEnum Company { get; set; }
        public int InvocieNumber { get; set; }
        public Client ClientName { get; set; }
        public int Amount { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DueDate { get; set; }
        public bool Payed { get; set; }
        public Invoice(CompanyEnum company, Client clientName, int amount, DateTime issueDate, bool payed)
        {
            Company = company;
            InvocieNumber = new Random().Next(10, 100) + new Random().Next(10, 1000);
            ClientName = clientName;
            Amount = amount;
            DateOfIssue = issueDate;
            DueDate = DateOfIssue.AddDays(30);
            Payed = payed;
        }
        public string InvoiceInfo()
        {
            string invoicePayed = Payed == true ? "Yes" : "No";

            return $"\nFrom : {Company} \n" +
                $"To : {ClientName.UserName} \n" +
                $"Date of issue : {DateOfIssue.ToString("MMM", CultureInfo.InvariantCulture)} {DateOfIssue.ToString("yyyy")} \n" +
                $"Due Date : {DueDate.ToString("dd/MMM/yyyy")}\n" +
                $"Amount : {Amount} \n" +
                $"Invoice no. {InvocieNumber}\n" +
                $"Status payed : {invoicePayed}";
        }
        public void PenaltyPayment()
        {
            DueDate.ToString("yyyyy-MM-dd-HH-mm-ss");
            
            int result = DateTime.Compare(DueDate, DateTime.Now);
            if(result < 0)
            {
                double totalDays = (DateTime.Now - DueDate).TotalDays;
                totalDays = Math.Truncate(totalDays);
                int penaltyFee = (int)(totalDays * 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Penalty Payment");
                Console.WriteLine($"{totalDays} days overdue\n{Amount} + {totalDays*10} penalty fee\nNew amount {totalDays * 10 + Amount}\n");
                Console.ResetColor();
                Amount += penaltyFee;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No penalty fee\n");
                Console.ResetColor();
            }

        }
    }
}
