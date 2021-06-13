using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class DbManufacturer 
    {
        public static List<Vehicle> NewVehicles;
        static DbManufacturer()
        {
            NewVehicles = new List<Vehicle>
            {
                new Car("Mercedes-Benz", "E-Class", Enums.EngineEnum.Petrol, 3000, 250, Enums.TransmissionEnum.Manual, 55000),
                new Car("BMW", "5-Series", Enums.EngineEnum.Petrol, 3000, 280, Enums.TransmissionEnum.Manual, 50000),
                new Car("Seat", "Leon", Enums.EngineEnum.Petrol, 1200, 150, Enums.TransmissionEnum.Manual, 12000),
                new Truck("Scania","R-550", Enums.EngineEnum.Diesel, 15500, 580, Enums.TransmissionEnum.SemiAutomatic, 110000, 2, true),
                new Van("Volkswagen", "Crafter", Enums.EngineEnum.Diesel, 2000, 150, Enums.TransmissionEnum.Manual, 22000, 1500),
                new Van("Mercedes-Benz ", "Vito", Enums.EngineEnum.Diesel, 2500, 190, Enums.TransmissionEnum.Manual, 29000, 2500)
            };
        }
    }
}
