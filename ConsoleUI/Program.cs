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
            //CarManager manager = new CarManager(new EfCarDal());

            //ADD OPERATION
            /*UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User {
                Email = "fatih@gmail.com",
                FirstName="Fatih",
                LastName="Öztemir",
                Password="1",
            }) ;
            userManager.Add(new User
            {
                Email = "Tuğçe@gmail.com",
                FirstName = "Tuğçe",
                LastName = "Kazaz",
                Password = "1",
            });
            userManager.Add(new User
            {
                Email = "Engin@gmail.com",
                FirstName = "Engin",
                LastName = "Demiroğ",
                Password = "1",
            });*/

            //Customer Add Operation
            /*CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                UserId=3,
                CompanyName="Kodlama.io"
            });*/

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           var x= rentalManager.Add(new Rental
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = DateTime.Now.AddDays(1),
                ReturnDate = DateTime.Now
            }) ;
            Console.WriteLine(x.Message);
            list(rentalManager);

        }
        private static void list(RentalManager manager)
        {
            var result = manager.GetAll();
            if (result.Success)
            {
                foreach (var user in manager.GetAll().Data)
                {
                    Console.WriteLine("carid " + user.CarId + "");
                }
                Console.WriteLine("Operation Completed");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
