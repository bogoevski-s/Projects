using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Car : Vehicle
    {
        public int WheelSize { get; set; }
        public bool ParkingSensor { get; set; }
        public bool Navigation { get; set; }
        public bool LaneAssistant { get; set; }
        public bool AdaptiveCruiseControl { get; set; }

        public Car(string brand, string model, EngineEnum engineType, int engineCC, int power, TransmissionEnum transmission, int price) : base (brand, model, engineType, engineCC, power, transmission, price)
        {
            WheelSize = 16;
            ParkingSensor = false;
            Navigation = false;
            LaneAssistant = false;
            AdaptiveCruiseControl = false;
        }
        public Car()
        {

        }
        public override string VehicleInfo()
        {
            //string haveSensors = ParkingSensor ? "Yes" : "No";
            //string haveNavi = Navigation ? "Yes" : "No";
            //string haveLaneAssistant = LaneAssistant ? "Yes" : "No";
            //string haveCruiseControl = AdaptiveCruiseControl ? "Yes" : "No";
            return $"{"Type :",-25} {Type,-25}\n{"Vehicle ID :",-25} {Id,-25}\n{"Brand :",-25} {Brand,-25}\n{"Model :",-25} {Model,-25}\n{"Fuel :",-25} {EngineType,-5} + optional hybrid / diesel / electric\n{"Engin Capacity :",-25} {EnginceCapacityCC,-25}" +
                $"\n{"Transmission :",-25} {Transmission,-5} + optional Automatic / SemiAutomatic\n{"Price :",-25} {Price,3} $\n{"Power :",-25} {Power,0} {"PS",1}\n{"Status :",-25} {Status,0}\n{"WheelSize :",-25} {WheelSize,0} inch + extra option\n{"ParkingSensor :",-25} extra option\n{"Navigation :",-25} extra option\n" +
                $"{"LaneAssistant :",-25} extra option\n{"AdaptiveCruiseControl :",-25} extra option\n\n";
        }
        public void CalculatePrice()
        {
            if (WheelSize == 17) Price += 400;

            if (WheelSize == 18) Price += 550;

            if (Navigation == true) Price += 700;

            if (ParkingSensor == true) Price += 400;

            if (LaneAssistant == true) Price += 900;

            if (AdaptiveCruiseControl == true) Price += 800;

            if (EngineType == EngineEnum.Diesel) Price += (5 * Price) / 100;

            if (EngineType == EngineEnum.Hybrid) Price += (15 * Price) / 100;

            if (EngineType == EngineEnum.Electric) Price += (25 * Price) / 100;
        }
        public string VehiclePurchaseInfo()
        {
            string haveSensors = ParkingSensor ? "Yes" : "No";
            string haveNavi = Navigation ? "Yes" : "No";
            string haveLaneAssistant = LaneAssistant ? "Yes" : "No";
            string haveCruiseControl = AdaptiveCruiseControl ? "Yes" : "No";
            return $"{base.VehicleInfo()}{"WheelSize :",-25} {WheelSize,0} inch\n{"ParkingSensor :",-25} {haveSensors,-25}\n{"Navigation :",-25} {haveNavi,-25}\n" +
                $"{"LaneAssistant :",-25} {haveLaneAssistant,-25}\n{"AdaptiveCruiseControl :",-25} {haveCruiseControl,-25}\n\n";
        }
    }
}
