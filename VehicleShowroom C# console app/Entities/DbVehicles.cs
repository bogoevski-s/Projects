using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class DbVehicles
    {
        public static List<Vehicle> Vehicles;
        static DbVehicles()
        {
            Vehicles = new List<Vehicle>
            {
                new Car("Peugeot", "508", Enums.EngineEnum.Petrol, 2000, 160, Enums.TransmissionEnum.Manual, 31000),
                new Truck("Man","TGA", Enums.EngineEnum.Diesel, 12500, 450, Enums.TransmissionEnum.SemiAutomatic, 90000, 2, true),
                new Van("Iveco", "Daily", Enums.EngineEnum.Diesel, 3000, 180, Enums.TransmissionEnum.Manual, 25000, 2000),
                new Car("Toyota", "RAV4", Enums.EngineEnum.Petrol, 1500, 120, Enums.TransmissionEnum.Manual, 40000),
                new Car("VW", "Golf", Enums.EngineEnum.Petrol, 1600, 150, Enums.TransmissionEnum.Manual, 15000)
            };
        }
    }
}
