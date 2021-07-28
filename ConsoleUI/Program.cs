using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager manager = new CarManager(new InMemoryCarDal());
            list(manager);
            manager.Add(new Car { Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 120, Description = "AddDescription", ModelYear = 2016 });
            list(manager);
            manager.Update(new Car { Id = 4, ModelYear = 2019 });
            list(manager);
        }
        private static void list(CarManager manager)
        {
            foreach (var car in manager.GetAll())
            {
                Console.WriteLine("ID " + car.Id + "  YEAR " + car.ModelYear);
            }
        }
    }
}
