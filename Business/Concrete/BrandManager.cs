using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

   
        [SecuredOperation("brand.add")] // authorzition yetki kontrolu
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IBrandService.Get")] //interfacedeki butun getleri sil
        public IResult Add(Brand brand)
        {
            //business code ?

            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
           
        }

        //public void delete(Brand brand)  eskisi 
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccessResult(Messages.BrandDeleted);  //böyle demek için ctor yapısı olusutrulmalı 
        }

        public IDataResult<List<Brand>> GetAll()
        {
            //if (DateTime.Now.Hour==1)
            //{
            //    return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            //}
           return new SuccessDataResult<List<Brand>>( _brandDal.GetAll(),Messages.BrandsListed);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Brand> GetById(int brandId)
        {
           return new SuccessDataResult<Brand>(_brandDal.Get(x => x.BrandId == brandId),Messages.FilterId);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
