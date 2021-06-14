using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Brand brand)
        {
            //business code ?
            if (brand.BrandName.Length<2)
            {
                //magic string tercih edilmiyor 
                return new ErrorResult(Messages.BrandNameInValid);
            }

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
