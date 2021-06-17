using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  
    public class CarManager : ICarService  
    {
        ICarDal _carDal;  //injektion yapısı ctor ile ekle 
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //filtre verelim :
        //araba ismi  minumum 2 karakter olmalı
        //araba günlük fiyatı 0 dan büyük olmalı


        [ValidationAspect(typeof (CarValidator))]
        public IResult add(Car car)
        {
            if (car.Description.Length<2 && car.DailyPrice<=0)
            {
                return new ErrorResult(Messages.CarNameInValid);
            }
            _carDal.Add(car);
            

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()  
        {
            //İş kodları yazılır
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetBrandByBrandId(int Id)  //markaya göre filtelenmiş ürün listesi
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == Id), Messages.FilterId);
        }

        public IDataResult<Car> GetById(int id)
        {
           return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == id),Messages.FilterId);
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min , decimal max)  // 0 dan fazla olan ürünleri getirir
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <=max),Messages.FilterId);  //iki fiyat aralıgında olan ürünler 
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min)
        {
          return new SuccessDataResult<List<Car>>( _carDal.GetAll(x => x.DailyPrice >= min),Messages.FilterId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //iş kuralı varsa ??
          
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IResult update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
