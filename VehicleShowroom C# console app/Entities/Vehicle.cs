using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;


namespace Entities
{
    public abstract class Vehicle
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public EngineEnum EngineType { get; set; }
        public int EnginceCapacityCC { get; set; }
        public int Power { get; set; }
        public TransmissionEnum Transmission { get; set; }
        public int Price { get; set; }
        public VehicleStatusEnum Status { get; set; }
        public Vehicle(string brand, string model, EngineEnum engineType, int engineCC, int power, TransmissionEnum transmission, int price)
        {
            Type = GetType().Name;
            Id = new Random().Next(10, 100) + new Random().Next(10, 1000);
            Brand = brand;
            Model = model;
            EngineType = engineType;
            EnginceCapacityCC = engineCC;
            Power = power;
            Transmission = transmission;
            Price = price;
            Status = VehicleStatusEnum.Available;
        }
        public Vehicle()
        {

        }
        public virtual string VehicleInfo()
        {
            return $"{"Type :",-25} {Type,-25}\n{"Vehicle ID :",-25} {Id,-25}\n{"Brand :",-25} {Brand,-25}\n{"Model :",-25} {Model,-25}\n{"Fuel :",-25} {EngineType,-5}\n{"Engin Capacity :",-25} {EnginceCapacityCC,-25}" +
                $"\n{"Transmission :",-25} {Transmission,-5}\n{"Price :",-25} {Price,3} $\n{"Power :",-25} {Power,0} {"PS",1}\n{"Status :",-25} {Status,0}\n";
        }

    }
}
