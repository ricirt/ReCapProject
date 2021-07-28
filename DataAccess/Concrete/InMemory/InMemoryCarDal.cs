using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id=1,
                    BrandId=1,
                    ColorId=1,
                    DailyPrice=20,
                    Description="Araba Kiralıktır1",
                    ModelYear=1998
                },
                 new Car
                {
                    Id=2,
                    BrandId=1,
                    ColorId=2,
                    DailyPrice=10,
                    Description="Araba Kiralıktır2",
                    ModelYear=2021
                },               
                new Car
                {
                    Id=3,
                    BrandId=2,
                    ColorId=1,
                    DailyPrice=100,
                    Description="Araba Kiralıktır3",
                    ModelYear=2012
                }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car car = _cars.SingleOrDefault(c => c.Id == id);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
