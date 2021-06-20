using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImagesService
    {
      
            IResult Add(CarImages carImages);
            IResult Update(CarImages carImages);
            IResult Delete(CarImages carImages);
            IDataResult<List<CarImages>> GetAllCarImages();
            IDataResult<CarImages> GetCarImage(int id);
            IDataResult<List<CarImages>> GetCarImageByCarId(int carId);
      
    }
}
