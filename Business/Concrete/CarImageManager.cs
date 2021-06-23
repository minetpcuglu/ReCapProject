using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImageManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImages)
        {
            IResult result = BusinessRules.Run(CheckCarMaxImageLimit(carImages.CarId));
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImage carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(),Messages.CarsImagesListed);
        }

        public IDataResult<CarImage> GetCarImage(int id)
        {
            
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(x => x.CarImagesId == id), Messages.FilterId);
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(x => x.CarId == carId), Messages.FilterId);
        }

        public IResult Update(CarImage carImages)
        {
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.CarIamgesUpdated);
        }

        //Bir arabanın en fazla 5 resmi olabilir.
        private IResult CheckCarMaxImageLimit(int id)
        {
            var result = _carImagesDal.GetAll(x => x.CarId == id).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.CarMaxImageLimit);
            }
            return new SuccessResult();
        }
    }
}
