using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length>2 && car.DailyPrice>0)
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p=>p.Id==id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public Car GetCarsByBrandId(int id)
        {
            return _carDal.Get(c => c.BrandId == id);
        }

        public Car GetCarsByColorId(int id)
        {
            return _carDal.Get(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
