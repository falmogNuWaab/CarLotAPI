using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCCarDealershipAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LotController : ControllerBase
    {
        Inventory cl = new Inventory();
        
        [HttpGet]
        public List<Car> GetAllCars()
        {
            return cl.AllCars;
        }
        [HttpGet("GetCarByMake/{make}")]
        public List<Car> GetCarsByMake(string make)
        {
            List<Car> cars = new List<Car>();
            foreach(Car c in cl.AllCars)
            {
                if(c.Make.Contains(make) || c.Make.ToLower() == make.ToLower())
                {
                    cars.Add(c);
                }
            }
            return cars;
        }
        [HttpGet("GetCarsByColor/{color}")]
        public List<Car> GetCarsByColor(string color)
        {
            List<Car> cars = new List<Car>();
            foreach(Car c in cl.AllCars)
            {
                if(c.Color.Contains(color) || c.Color.ToLower() == color.ToLower())
                {
                    cars.Add(c);
                }
            }
            return cars;
        }
        [HttpGet("GetCarByIndex/{index}")]
        public string GetCarByIndex(int index)
        {
            Car errorCar = new Car("Error", "Index", index, "Is Invalid, Try Again");
            try
            {
                return cl.AllCars[index].ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                return $"{index} is not a valid Car ID. Please select a number between 0 - {cl.AllCars.Count-1}";
            }
            catch (IndexOutOfRangeException)
            {
                return $"{index} is not a valid Car ID. Please select a number between 0 - {cl.AllCars.Count - 1}";
            }
        }
        [HttpGet("SearchByAnything/{keyword}")]
        public List<Car> SearchByAnything(string keyword)
        {
            List<Car> toReturn = new List<Car>();
            keyword = keyword.Trim().ToLower();
            foreach(Car c in cl.AllCars)
            {
                string year = c.Year.ToString();
                if ((c.Color.ToLower() == keyword || c.Color.ToLower().Contains(keyword)) || 
                    (c.Make.ToLower() == keyword || c.Make.ToLower().Contains(keyword)) || 
                    (c.Model.ToLower() == keyword || c.Model.ToLower().Contains(keyword) || 
                    (year == keyword)))
                    {
                    toReturn.Add(c);
                }            
            }
            return toReturn;
        }
    }
}
