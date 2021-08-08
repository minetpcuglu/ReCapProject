using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService  //dıs dunyaya neyi servis etmek istiyorsak buraya yazarız 
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);

        IDataResult<Car> GetBrandByBrandId(int brandid);
        IDataResult<List<Car>> GetByUnitPrice(decimal min,decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddTransactionalTest(Car car);

        IResult add(Car car);
        IResult delete(Car car);
        IResult update(Car car);

        

    }
}
