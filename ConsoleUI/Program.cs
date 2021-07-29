using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
            foreach (var car in manager.GetAll())
            {
                Console.WriteLine("ID " + car.Id + "  YEAR " + car.ModelYear);
            }
            Console.WriteLine("Operation Completed");
        }
    }
}
