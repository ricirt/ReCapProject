using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _imageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal imageDal, IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _imageDal = imageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage image, IFormFile file)
        {
            //Logic Code Control
            var result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));
            if (!result.Success)
            {
                return result;
            }
            var imageResult = _fileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            image.CreateDate = DateTime.Now;
            image.Path = imageResult.Data;
            _imageDal.Add(image);

            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(CarImage image)
        {
            var result = _imageDal.Get(i => i.Id == image.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.ImagesNotFound);
            }
            _fileHelper.Delete(image.Path);
            _imageDal.Delete(image);
            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _imageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }
        public IDataResult<CarImage> GetById(int id)
        {
            var result = _imageDal.Get(i => i.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = _imageDal.GetAll(i => i.CarId == id);
            if (result != null)
                return new SuccessDataResult<List<CarImage>>(result);
            return new ErrorDataResult<List<CarImage>>(Messages.ImagesNotFound);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage image, IFormFile file)
        {
            var result  = _imageDal.Get(i => i.Id == image.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.ImagesNotFound);
            }
            var UpdatedFile = _fileHelper.Update(file, image.Path);
            image.Path = UpdatedFile.Data;
            image.CreateDate = result.CreateDate;
            _imageDal.Update(image);
            return new SuccessResult(Messages.CarImageUpdated);

        }
        //private IResult IsImageExist(int id)
        //{
        //    var result = _imageDal.Get(i => i.Id == id);
        //    if (result != null)
        //    {
        //        return new SuccessResult();
        //    }
        //    return new ErrorResult(Messages.ImagesNotFound);
        //}
        private IResult CheckImageLimitExceeded(int id)
        {
            var imagesCount = _imageDal.GetAll(i => i.CarId == id).Count;
            if (imagesCount >= 5)
            {
                return new ErrorResult(Messages.İmageCountInvalid);
            }
            return new SuccessResult();
        }
        //private IDataResult<Lis>
    }
}

