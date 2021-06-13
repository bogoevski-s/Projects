using System;
using Entities;
using System.Collections.Generic;
using System.Linq;


namespace VehicleShowroomApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Login\n2.New custumer <- Register here\n3.Exit");
                string loginRegister = Console.ReadLine();
                bool loginRegisterParsed = int.TryParse(loginRegister, out int loginRegisterNum);
                if(!loginRegisterParsed || loginRegisterNum > 3 || loginRegisterNum < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input!! Please try again");
                    Console.ReadLine();
                    continue;
                }
                if (loginRegisterNum == 1)
                {
                    Console.Clear();
                    User loggedInUser = Login();

                    if (loggedInUser.Role == Enums.RoleEnum.Client)
                    {
                        ClientMenu((Client)loggedInUser);
                    }
                    else if (loggedInUser.Role == Enums.RoleEnum.Sale)
                    {
                        SaleMenu((Sale)loggedInUser);
                    }
                    else if (loggedInUser.Role == Enums.RoleEnum.Merchant)
                    {
                        MerchantMenu((Merchant)loggedInUser);
                    }
                }
                else if (loginRegisterNum == 2)
                {
                    Console.Clear();
                    User newClient = Register();
                    DbUsers.Users.Add(newClient);
                    continue;
                }
                else if (loginRegisterNum == 3) return;
            }
            
        }
        static Client Register()
        {
            while (true)
            {
                Console.Write("Enter your first name: ");
                string newClientFirstName = Console.ReadLine();
                if (newClientFirstName.Length < 3)
                {
                    Console.Clear();
                    Console.WriteLine("Name too short\nPlease use your real name");
                    Console.ReadLine();
                    continue;
                }

                Console.Write("Enter your last name: ");
                string newClientLastName = Console.ReadLine();
                if (newClientLastName.Length < 3)
                {
                    Console.Clear();
                    Console.WriteLine("Last name too short\nPlease use your real surname");
                    Console.ReadLine();
                    continue;
                }
                Console.Write("Enter your email: ");
                string newClientEmail = Console.ReadLine();
                if (!newClientEmail.Contains("@") || !newClientEmail.Contains(".com"))
                {
                    Console.Clear();
                    Console.WriteLine($@"Wrong email input you're missing @ or "".com"" ");
                    Console.ReadLine();
                    continue;
                }
                Console.Write("Enter password: ");
                string newClientPassword = Console.ReadLine();
                if(newClientPassword.Length < 3)
                {
                    Console.Clear();
                    Console.WriteLine($@"Password too short Please use more than 3 characters");
                    Console.ReadLine();
                    continue;
                }
                Console.Clear();
                Console.WriteLine("Account successfuly created");
                Console.ReadLine();
                Client newClient = new Client(newClientFirstName, newClientLastName, newClientEmail, newClientPassword, Enums.RoleEnum.Client, 10000);
                return newClient;
            }
        }
        static User Login()
        {
            while (true)
            {
                Console.Write("Please enter your email: ");
                string email = Console.ReadLine();
                Console.Write("Please enter your password: ");
                string pass = Console.ReadLine();

                if (email == "" || pass == "")
                {
                    Console.Clear();
                    Console.WriteLine("You must enter email and password\n");
                    Console.ReadLine();
                    continue;
                    //throw new Exception("Email and password must contain at least 3 characters");
                }

                User loggedUser = DbUsers.Users.FirstOrDefault(x => x.Mail == email);

                if (loggedUser == null)
                {
                    Console.Clear();
                    Console.WriteLine($@"Sorry email ""{email}"" not exist{"\n"}");
                    Console.ReadLine();
                    continue;
                    //throw new Exception($"Sorry email {email} not exist");
                }

                if (!loggedUser.PasswordCheck(pass))
                {
                    Console.Clear();
                    Console.WriteLine("Wrong password please try again\n");
                    Console.ReadLine();
                    continue;
                }

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Welcome {loggedUser.FullName}\n\n");
                    Console.ResetColor();
                }
                
                return loggedUser;
            }
        }
        static void ClientMenu(Client client)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to SEDC Auto {client.FullName}\n");
                //Console.WriteLine($"Your Balance: {client.Balance}\n\n");
                Console.WriteLine($"1.View all vehicles\n2.Log out");
                string clientInput = Console.ReadLine();
                bool clientInputParse = int.TryParse(clientInput, out int clientInputNum);
                if (!clientInputParse || clientInputNum > 2 || clientInputNum < 1)
                {
                    Console.WriteLine("Wrong input");
                    Console.ReadLine();
                    continue;
                }
                if (clientInputNum == 1)
                {
                    Console.Clear();
                    foreach (Vehicle vehicle in DbVehicles.Vehicles)
                    {
                        if(vehicle.Status == Enums.VehicleStatusEnum.Reserved)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(vehicle.VehicleInfo());
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(vehicle.VehicleInfo());
                        }

                    }
                    Console.WriteLine($"1.Select Vehicle\n2.Log out");
                    string clientInputMenu1 = Console.ReadLine();
                    bool clientInputMenuParsed = int.TryParse(clientInputMenu1, out int clientInputMenuNum);
                    if (!clientInputMenuParsed || clientInputMenuNum > 2 || clientInputMenuNum < 1)
                    {
                        Console.WriteLine("Wrong input");
                        Console.ReadLine();
                        continue;
                    }
                    if (clientInputMenuNum == 1)
                    {
                        Console.Write("Please enter vehicle ID number : ");
                        string vehicleId = Console.ReadLine();
                        bool vehicleIdParsed = int.TryParse(vehicleId, out int vehicleIdNum);
                        if (!vehicleIdParsed)
                        {
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        SelectVehicle(vehicleIdNum);

                    }
                    else if (clientInputMenuNum == 2)
                        return;
                }
                else if (clientInputNum == 2)
                    return;
            }
        }
        static void SelectVehicle(int id)
        {
            while (true)
            {
                Vehicle selectedVehicle = DbVehicles.Vehicles.FirstOrDefault(x => x.Id == id);
                if (selectedVehicle == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vehicle not found");
                    Console.ResetColor();
                    Console.ReadLine();
                    //throw new Exception("Vehicle not found");
                    break;
                }
                if(selectedVehicle.Status == Enums.VehicleStatusEnum.Reserved || selectedVehicle.Status == Enums.VehicleStatusEnum.Sold)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vehicle not available\nPlease choose other vehicle");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
                }
                Car selectedCar = new Car();
                Truck selectedTruck = new Truck();
                Van selectedVan = new Van();

                if (selectedVehicle.Type == "Car")
                {
                    selectedCar = (Car)selectedVehicle;
                    Console.Clear();
                    Console.WriteLine(selectedCar.VehicleInfo());
                    Console.WriteLine($"1.Order base Vehicle \n2.Add Extras\n3.Return");
                    string selectedCarClientInput = Console.ReadLine();
                    bool clientInputParsed = int.TryParse(selectedCarClientInput, out int selectedCarInputNum);
                    if (!clientInputParsed || selectedCarInputNum > 3 || selectedCarInputNum < 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input!!!");
                        Console.ReadLine();
                        continue;
                    }
                    if (selectedCarInputNum == 1)
                    {
                        Console.Clear();
                        selectedCar.Status = Enums.VehicleStatusEnum.Reserved;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Vehicle successfuly reserved");
                        Console.ResetColor();
                        Console.ReadLine();
                        return;
                    }
                    if (selectedCarInputNum == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Choose wheel size : \n1.16 inch(standard)\n2.17 inch\n3.18 inch");
                        string wheelSize = Console.ReadLine();
                        bool wheelSizeParsed = int.TryParse(wheelSize, out int wheelSizeNum);
                        if(!wheelSizeParsed || wheelSizeNum > 3 || wheelSizeNum < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong Input !!!");
                            Console.ReadLine();
                            continue;
                        }
                        if (wheelSizeNum == 2)
                        {
                            wheelSizeNum = 17;
                            selectedCar.WheelSize = 17;
                        }

                        else if (wheelSizeNum == 3)
                        {
                            wheelSizeNum = 18;
                            selectedCar.WheelSize = 18;
                        }

                        Console.Clear();
                        Console.WriteLine($"Parking sensors\n1.Yes\n2.No");
                        string parkingSensors = Console.ReadLine();
                        bool parkingSensorParsed = int.TryParse(parkingSensors, out int parkingSensorNum);
                        if(!parkingSensorParsed || parkingSensorNum > 2 || parkingSensorNum < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        if(parkingSensorNum == 1)
                        {
                            selectedCar.ParkingSensor = true;
                        }

                        Console.Clear();
                        Console.WriteLine($"Navigation\n1.Yes\n2.No");
                        string navigation = Console.ReadLine();
                        bool navigationParsed = int.TryParse(navigation, out int navigationNumInput);
                        if (!navigationParsed || navigationNumInput > 2 || navigationNumInput < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        if(navigationNumInput == 1)
                        {
                            selectedCar.Navigation = true;
                        }

                        Console.Clear();
                        Console.WriteLine($"Lane Assistant\n1.Yes\n2.No");
                        string laneAssistant = Console.ReadLine();
                        bool laneAssistantParsed = int.TryParse(laneAssistant, out int laneAssistantNum);
                        if (!laneAssistantParsed || laneAssistantNum > 2 || laneAssistantNum < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        if(laneAssistantNum == 1)
                        {
                            selectedCar.LaneAssistant = true;
                        }

                        Console.Clear();
                        Console.WriteLine($"Adaptive Cruise Control\n1.Yes\n2.No");
                        string cruiseControl = Console.ReadLine();
                        bool cruiseControlParsed = int.TryParse(cruiseControl, out int cruiseControlNum);
                        if (!cruiseControlParsed || cruiseControlNum > 2 || cruiseControlNum < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        if(cruiseControlNum == 1)
                        {
                            selectedCar.AdaptiveCruiseControl = true;
                        }

                        Console.Clear();
                        Console.WriteLine($"Choose Engine : \n1.Petrol (standard)\n2.Diesel + 5%\n3.Hybrid + 15%\n4.Electric + 25%");
                        string engineChoose = Console.ReadLine();
                        bool engineChooseParse = int.TryParse(engineChoose, out int engineChooseNum);
                        if (!engineChooseParse || engineChooseNum > 4 || engineChooseNum < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        if (engineChooseNum == 2)
                        {
                            selectedCar.EngineType = Enums.EngineEnum.Diesel;
                        }
                        else if (engineChooseNum == 3)
                        {
                            selectedCar.EngineType = Enums.EngineEnum.Hybrid;
                        }
                        else if (engineChooseNum == 4)
                        {
                            selectedCar.EngineType = Enums.EngineEnum.Electric;
                        }

                        Console.Clear();
                        Console.WriteLine($"Choose transmission : \n1.Manual (standard)\n2.Automatic + 1000$\n3.SemiAutomatic + 1400$");
                        string transmissionChoose = Console.ReadLine();
                        bool transmissionChooseParse = int.TryParse(transmissionChoose, out int transmissionChooseNum);
                        if (!transmissionChooseParse || transmissionChooseNum > 3 || transmissionChooseNum < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        if (transmissionChooseNum == 2)
                        {
                            selectedCar.Transmission = Enums.TransmissionEnum.Automatic;
                        }
                        else if (transmissionChooseNum == 3)
                        {
                            selectedCar.Transmission = Enums.TransmissionEnum.SemiAutomatic;
                        }

                        selectedCar.CalculatePrice();
                        Console.Clear();
                        Console.WriteLine(selectedCar.VehiclePurchaseInfo());
                        Console.WriteLine("Order this vehicle?\n1.Yes\n2.No");
                        string orderVehicle = Console.ReadLine();
                        bool orderVehicleParsed = int.TryParse(orderVehicle, out int orderVehicleNum);
                        if (!orderVehicleParsed || orderVehicleNum > 2 || orderVehicleNum < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!!");
                            Console.ReadLine();
                            continue;
                        }
                        if (orderVehicleNum == 1)
                        {
                            Console.Clear();
                            selectedCar.Status = Enums.VehicleStatusEnum.Reserved;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Successfuly order vehicle");
                            Console.WriteLine($"Vehicle Status : {selectedCar.Status}");
                            Console.ResetColor();
                            Console.ReadLine();
                            return;
                        }
                    }
                    if (selectedCarInputNum == 3)
                    {
                        return;
                    }
                }
                else if (selectedVehicle.Type == "Truck")
                {
                    selectedTruck = (Truck)selectedVehicle;
                    Console.Clear();
                    Console.WriteLine(selectedTruck.VehicleInfo());
                    Console.WriteLine($"1.Order this vehicle\n2.Add second trailer\n3.Return");
                    string selectedTruckInput = Console.ReadLine();
                    bool selectedTruckParse = int.TryParse(selectedTruckInput, out int selectedTruckMenuNum);
                    if(!selectedTruckParse || selectedTruckMenuNum > 3 || selectedTruckMenuNum < 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input!!");
                        Console.ReadLine();
                        continue;
                    }
                    if (selectedTruckMenuNum == 1)
                    {
                        Console.Clear();
                        selectedTruck.Status = Enums.VehicleStatusEnum.Reserved;
                        selectedTruck.BaseTruck();
                        Console.WriteLine(selectedTruck.VehicleInfo());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfuly order vehicle");
                        Console.WriteLine($"Vehicle Status : {selectedTruck.Status}");
                        Console.ResetColor();
                        Console.ReadLine();
                        return;
                    }
                    else if (selectedTruckMenuNum == 2)
                    {
                        Console.Clear();
                        selectedTruck.Trailers = 2;
                        selectedTruck.SecondTrailer();
                        selectedTruck.Status = Enums.VehicleStatusEnum.Reserved;
                        Console.WriteLine(selectedTruck.VehicleInfo());
                        Console.WriteLine("\nYou get 10% off for second trailer\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfuly order vehicle");
                        Console.WriteLine($"Vehicle Status : {selectedTruck.Status}");
                        Console.ResetColor();
                        Console.ReadLine();
                        return;
                    }
                    else if (selectedTruckMenuNum == 3) return;

                }
                else if (selectedVehicle.Type == "Van")
                {
                    selectedVan = (Van)selectedVehicle;
                    Console.Clear();
                    Console.WriteLine(selectedVan.VehicleInfo());
                    Console.WriteLine($"1.Order this Vehicle (no extras for this vehicle)\n2.Return");
                    string selecteVanClientInput = Console.ReadLine();
                    bool clientInputVanParsed = int.TryParse(selecteVanClientInput, out int selectedVanInputNum);
                    if (!clientInputVanParsed || selectedVanInputNum > 3 || selectedVanInputNum < 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input!!!");
                        Console.ReadLine();
                        continue;
                    }
                    if (selectedVanInputNum == 1)
                    {
                        Console.Clear();
                        selectedVan.Status = Enums.VehicleStatusEnum.Reserved;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfuly order vehicle");
                        Console.WriteLine($"Vehicle Status : {selectedVan.Status}");
                        Console.ResetColor();
                        Console.ReadLine();
                        return;
                    }
                    else if (selectedVanInputNum == 2) break;

                }
            }
            

            
        }
        static void SaleMenu(Sale salePerson)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"1.View all vehicles\n2.View all reserved vehicles\n3.Logut");
                string saleMenuInput = Console.ReadLine();
                bool saleMenuParsed = int.TryParse(saleMenuInput, out int saleMenuInputNum);
                if (!saleMenuParsed || saleMenuInputNum > 3 || saleMenuInputNum < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input!!");
                    Console.ReadLine();
                    continue;
                }
                if (saleMenuInputNum == 1)
                {
                    Console.Clear();
                    foreach (Vehicle vehicle in DbVehicles.Vehicles)
                    {
                        if (vehicle.Status == Enums.VehicleStatusEnum.Reserved)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(vehicle.VehicleInfo());
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(vehicle.VehicleInfo());
                        }
                    }
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadLine();
                    continue;

                }
                if (saleMenuInputNum == 2)
                {
                    Console.Clear();
                    int counter = 0;
                    foreach (Vehicle vehicle in DbVehicles.Vehicles)
                    {
                        if (vehicle.Status == Enums.VehicleStatusEnum.Reserved)
                        {
                            Console.WriteLine(vehicle.VehicleInfo());
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There is no reserved vehicles\n");
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine("1.Approve Order\n2.Reject Order\n3.Return");
                    string saleOrderMenu = Console.ReadLine();
                    bool saleOrderParsed = int.TryParse(saleOrderMenu, out int saleOrderMenuNumber);
                    if(!saleOrderParsed || saleOrderMenuNumber > 3 || saleOrderMenuNumber < 1)
                    {
                        Console.WriteLine("Wrong input!!");
                        Console.ReadLine();
                        continue;
                    }
                    if(saleOrderMenuNumber == 1)
                    {
                        Console.Write("Enter vehicle id number to approve the order : ");
                        string vehicleIdOrder = Console.ReadLine();
                        bool vehicleIdNumOrder = int.TryParse(vehicleIdOrder, out int vehicleIdOrderNum);
                        if (!vehicleIdNumOrder)
                        {
                            Console.WriteLine("Wrong input!!");
                            Console.ReadLine();
                            continue;
                        }
                        Vehicle selectedVehicle = DbVehicles.Vehicles.FirstOrDefault(x => x.Id == vehicleIdOrderNum);
                        DbVehicles.Vehicles.Remove(selectedVehicle);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Purchase completed");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    }
                    if (saleOrderMenuNumber == 2)
                    {
                        Console.Write("Enter vehicle ID :");
                        string vehicleIdReject = Console.ReadLine();
                        bool vehicleIdNumRejectParsed = int.TryParse(vehicleIdReject, out int vehicleIdRejectNum);
                        if (!vehicleIdNumRejectParsed)
                        {
                            Console.WriteLine("Wrong input!!");
                            Console.ReadLine();
                            continue;
                        }
                        Vehicle selectedVehicle = DbVehicles.Vehicles.FirstOrDefault(x => x.Id == vehicleIdRejectNum);
                        if (selectedVehicle == null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Vehicle with ID {vehicleIdReject} not found please try again");
                            //throw new Exception("Vehicle not found");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine("Rejection message : ");
                        string rejectMassage = Console.ReadLine();  
                        selectedVehicle.Status = Enums.VehicleStatusEnum.Available;

                        Console.Clear();
                        Console.WriteLine("Rejection completed");
                        Console.ReadLine();
                        break;
                    }
                    if (saleOrderMenuNumber == 3) break;
                }
                if (saleMenuInputNum == 3) break;

                Console.ReadLine();
            }
            
        }
        static void MerchantMenu(Merchant merchant)
        { 
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"1.View all vehicles on stock\n2.Order new vehicles\n3.Logut");
                string merchantMenuInput = Console.ReadLine();
                bool merchantMenuParsed = int.TryParse(merchantMenuInput, out int merchantMenuInputNum);
                if (!merchantMenuParsed || merchantMenuInputNum > 3 || merchantMenuInputNum < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input!!");
                    Console.ReadLine();
                    continue;
                }
                if (merchantMenuInputNum == 1)
                {
                    Console.Clear();
                    foreach (Vehicle vehicle in DbVehicles.Vehicles)
                    {
                        if (vehicle.Status == Enums.VehicleStatusEnum.Reserved)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(vehicle.VehicleInfo());
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(vehicle.VehicleInfo());
                        }
                    }
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadLine();
                    continue;
                }
                else if (merchantMenuInputNum == 2)
                {
                    Console.Clear();
                    foreach (Vehicle vehicle in DbManufacturer.NewVehicles)
                    {
                        Console.WriteLine(vehicle.VehicleInfo());
                    }
                    Console.WriteLine("1.Order vehicle\n2.Return");
                    string merchantOrder = Console.ReadLine();
                    bool merchantOrderParsed = int.TryParse(merchantOrder, out int merchantOrderNum);
                    if(!merchantMenuParsed || merchantMenuInputNum > 2 || merchantMenuInputNum < 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input!!! Please try again");
                        Console.ReadLine();
                        continue;
                    }
                    if (merchantOrderNum == 1)
                    {
                        Console.Write("Enter vehicle ID to make an order : ");
                        string orderNewVehicle = Console.ReadLine();
                        bool orderVehicleParsed = int.TryParse(orderNewVehicle, out int orderNewVehicleNum);
                        if (!orderVehicleParsed)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input!!! Please try again");
                            Console.ReadLine();
                            continue;
                        }
                        Vehicle newOrderdVehicle = DbManufacturer.NewVehicles.FirstOrDefault(x => x.Id == orderNewVehicleNum);
                        if (newOrderdVehicle == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Vehicle ID not found \nPlease try again");
                            //throw new Exception("Vehicle ID not found \nPlease try again");
                            Console.ReadLine();
                            continue;
                        }
                        Console.Clear();
                        DbVehicles.Vehicles.Add(newOrderdVehicle);

                        DbManufacturer.NewVehicles.Remove(newOrderdVehicle);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfuly purchase vehicle");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to return ");
                        Console.ReadLine();
                        break;
                    }
                    else if (merchantOrderNum == 2) break;

                }
                else if (merchantMenuInputNum == 3) break;
            }
        }
    }
}
