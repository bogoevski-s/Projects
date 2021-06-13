using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Invoice_App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new Client("Pero", "pero@yahoo.com", "123", 3000, RoleEnum.Client),
                new Admin("Bob", "bob@gmail.com", "123", RoleEnum.Admin, CompanyEnum.Evn),
                new Client("SlaveB", "slave@gmail.com", "123", 3000, RoleEnum.Client),
                new Admin("Aleksandar", "aleksandar@gmail.com", "123", RoleEnum.Admin, CompanyEnum.Vodovod),
                new Admin("Sam", "sam@gmail.com", "123", RoleEnum.Admin, CompanyEnum.Beg),
                new Admin("Ivo", "ivo@gmail.com", "123", RoleEnum.Admin, CompanyEnum.A1),
                new Client("Kiko", "kiko@gmail.com", "123", 8800, RoleEnum.Client),
                new Admin("Risto", "risto@gmail.com", "123", RoleEnum.Admin, CompanyEnum.Telekom)
            };

            List<Client> clients = new List<Client>();

            foreach (User client in users)
            {
                if (client.Role == RoleEnum.Client)
                {
                    clients.Add((Client)client);
                }
            }
            Random randomNum = new Random();
            int randomNumClient = randomNum.Next(0, clients.Count);

            List<Invoice> invoiceList = new List<Invoice>
            {
                new Invoice(CompanyEnum.Telekom,  clients[randomNum.Next(0, clients.Count)], 990, new DateTime(2021,03,30), false),
                new Invoice(CompanyEnum.Telekom,  clients[randomNum.Next(0, clients.Count)], 1054, new DateTime(2021,04,2), false),
                new Invoice(CompanyEnum.Evn, clients[randomNum.Next(0, clients.Count)], 2750, new DateTime(2021,05,30), false),
                new Invoice(CompanyEnum.Evn, clients[randomNum.Next(0, clients.Count)], 2750, new DateTime(2021,05,30), false),
                new Invoice(CompanyEnum.Vodovod, clients[randomNum.Next(0, clients.Count)], 350, new DateTime(2021,01,11), false),
                new Invoice(CompanyEnum.Beg, clients[randomNum.Next(0, clients.Count)], 350, new DateTime(2021,02,9), false),
                new Invoice(CompanyEnum.A1, clients[randomNum.Next(0, clients.Count)], 350, new DateTime(2021,05,30), false),
                new Invoice(CompanyEnum.A1, clients[randomNum.Next(0, clients.Count)], 350, new DateTime(2021,05,30), false),
                new Invoice(CompanyEnum.Evn, clients[randomNum.Next(0, clients.Count)], 350, new DateTime(2021,03,28), false)
            };  

            foreach (Invoice invoices in invoiceList)
            {
                foreach (Client client in clients)
                {
                    if (invoices.ClientName.UserName == client.UserName)
                    {
                        client.InvoicesList.Add(invoices);
                    }
                }
            }

            Client clientUser = null;
            Admin AdminUser = null;
            while (true)
            {
                Console.Clear();
                User user = Login(users);

                if (user.Role == RoleEnum.Admin)
                {

                    AdminUser = (Admin)user;
                    AdminUser.AdminInvoices(invoiceList);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                }
                else
                {
                    clientUser = (Client)user;
                    ClientMenu(clientUser);
                    continue;
                }
            }
        }
        static User Login(List<User> users)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"- - - - INVOICE APP - - - - \n\n");
            Console.ResetColor();
            while (true)
            {
                Console.WriteLine("Enter you email and password\n");
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("password: ");
                string pass = Console.ReadLine();
                Console.Clear();

                if (email.Length == 0 || pass.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fields must not be empty\n");
                    Console.ResetColor();
                    continue;
                }
                else if (!email.Contains("@") || !email.Contains(".com"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($@"Wrong email input you're missing @ or "".com"" ");
                    Console.ResetColor();
                    continue;
                }

                User loginUser = users.FirstOrDefault(x => x.Email == email);
                if (loginUser == null)
                {
                    Console.WriteLine("User email not found!!!");
                    throw new NullReferenceException("User email not found!!!");
                }
                if (loginUser.CheckPassword(pass))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Welcome {loginUser.UserName}\n");
                    Console.ResetColor();
                    return loginUser;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong password!!!\n");
                    Console.ResetColor();
                    continue;
                }
            }
        }

        static void ClientMenu(Client client)
        {
            while (true)
            {
                Console.WriteLine("1.View all invocies\n2.Pay invoice\n3.Balance\n4.Log out\n");
                string clientMenuInput = Console.ReadLine();
                bool menuInputParse = int.TryParse(clientMenuInput, out int clientInputNum);

                if (!menuInputParse || clientInputNum > 4 || clientInputNum < 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!!!\nPlease use numbers 1 - 4\n");
                    Console.ResetColor();
                    continue;
                }

                if (clientInputNum == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("All Invoices\n");
                    Console.ResetColor();

                    Console.WriteLine($"Balance: {client.CheckBalance()}\n");
                    client.AllInvoices();

                    Console.WriteLine("\n1.Pay invocie by invoice No.\n2.Return\n");
                    string clientAllInvociesInput = Console.ReadLine();
                    bool allInvociesParse = int.TryParse(clientAllInvociesInput, out int clientAllInvociesInputNum);

                    if (!allInvociesParse || clientAllInvociesInputNum > 2 || clientAllInvociesInputNum < 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input!!!\nPlease select numberic value from menu numbers\n");
                        Console.ResetColor();
                        continue;
                    }

                    if (clientAllInvociesInputNum == 1)
                    {
                        PayInvocie(client);
                    }

                    else if (clientAllInvociesInputNum == 2)
                    {
                        Console.Clear();
                        continue;
                    }
                }

                else if (clientInputNum == 2)
                {
                    Console.Clear();
                    client.AllInvoices();
                    PayInvocie(client);
                }

                else if (clientInputNum == 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Balance: {client.CheckBalance()}\n");
                    Console.ResetColor();

                    while (true)
                    {
                        Console.WriteLine("\n1.Deposit\n2.Return");
                        string balanceInput = Console.ReadLine();
                        bool balanceInputParse = int.TryParse(balanceInput, out int balanceInputNum);

                        if (!balanceInputParse || balanceInputNum > 2 || balanceInputNum < 1)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nWrong input\n");
                            Console.ResetColor();
                            continue;
                        }

                        else if (balanceInputNum == 1)
                        {
                            Console.Clear();
                            Console.Write("Enter amount to add to balance:");
                            string addBalanceInput = Console.ReadLine();
                            bool addBalanceParse = int.TryParse(addBalanceInput, out int addBalanceNumber);

                            if (!addBalanceParse || addBalanceNumber < 1)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input\nCant add negative numbers or characters. Please try again");
                                Console.ResetColor();
                                continue;
                            }

                            client.AddBalance(addBalanceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nNew Balance: {client.CheckBalance()}");
                            Console.ResetColor();
                            break;
                        }

                        else if (balanceInputNum == 2)
                        {
                            Console.Clear();
                            break;
                        }
                    }

                }
                else if (clientInputNum == 4) break;
            }
        }

        static void PayInvocie(Client client)
        {
            Console.Write("Please Enter invoice number :");

            string clientPayInput = Console.ReadLine();
            bool payInputParse = int.TryParse(clientPayInput, out int clientPayInputNum);
            if (!payInputParse)
            {
                Console.WriteLine("Wrong input!!!");
            }
            else
            {
                client.PayInvoice(clientPayInputNum);
                Console.WriteLine($"New Balance: {client.CheckBalance()}");
                client.AllInvoices();
            }
        }

    }
}
