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
        public IResult Add(CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckCarMaxImageLimit(carImages.CarId));
            carImages.Date = DateTime.Now.Date;
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImages carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        public IDataResult<List<CarImages>> GetAllCarImages()
        {
            _carImagesDal.GetAll();
            return new SuccessDataResult<List<CarImages>>(Messages.CarsImagesListed);
        }

        public IDataResult<CarImages> GetCarImage(int id)
        {
            
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(x => x.CarImagesId == id), Messages.FilterId);
        }

        public IDataResult<List<CarImages>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(x => x.CarId == carId), Messages.FilterId);
        }

        public IResult Update(CarImages carImages)
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
