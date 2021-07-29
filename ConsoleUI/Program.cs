using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager manager = new CarManager(new EfCarDal());
            
            list(manager);

        }
        private static void list(CarManager manager)
        {
            foreach (var car in manager.GetCarDetails())
            {
                Console.WriteLine("ID " + car.CarId + "  price  " + car.DailyPrice+" Brand "+car.BrandName+" Color "+car.ColorName);
            }
            Console.WriteLine("Operation Completed");
        }
    }
}
