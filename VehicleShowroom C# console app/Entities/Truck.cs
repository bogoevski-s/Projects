using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Truck : Vehicle
    {
        public int Axels { get; set; }
        public bool Sleeper { get; set; }
        public int Trailers { get; set; }
        public int PricePerTrailer { get; set; }

        public Truck(string brand, string model, EngineEnum engineType, int engineCC, int power, TransmissionEnum transmission, int price, int axels, bool sleeper) : base(brand, model, engineType, engineCC, power, transmission, price)
        {
            Axels = axels;
            Sleeper = sleeper;
            Trailers = 1;
            PricePerTrailer = 5000;
        }
        public Truck()
        {

        }
        public override string VehicleInfo()
        {
            string isSleeper = Sleeper ? "Yes" : "No";
            return $"{base.VehicleInfo()}{"Sleeper :",-25} {isSleeper,0}\n{"Axels :",-25} {Axels,0}\n{"Trailers :",-25} {Trailers,0} - Price of the trailer {PricePerTrailer}$\n" +
                $"{"Price with trailer/s :",-25} {Price,0}$\n\n";
        }
        public void BaseTruck()
        {
            Price += PricePerTrailer;
        }
        public void SecondTrailer()
        {
            int discount = PricePerTrailer - ((10 * 5000) / 100);
            Price += PricePerTrailer + discount;
        }
    }
}
