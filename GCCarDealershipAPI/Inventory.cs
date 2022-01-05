using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCarDealershipAPI
{
    public class Inventory
    {
        public List<Car> AllCars { get; set; } = new List<Car>();
        public Inventory()
        {
            AllCars.Add(new Car("Toyota", "Hilux", 1994, "White"));
            AllCars.Add(new Car("Toyota", "Corola", 1994, "Rust and Invisible"));
            AllCars.Add(new Car("Honda", "Civic", 1994, "Yellow"));
            AllCars.Add(new Car("Geo", "Metro", 1998, "White"));
            AllCars.Add(new Car("Toyota", "Hilux", 1999, "White"));
            AllCars.Add(new Car("Toyota", "T100", 1994, "White"));
            AllCars.Add(new Car("Mercury", "Hilux", 1994, "White"));
        }
    }
}
