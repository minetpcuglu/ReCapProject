using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImagesService
    {
      
            IResult Add(CarImage carImages);
            IResult Update(CarImage carImages);
            IResult Delete(CarImage carImages);
            IDataResult<List<CarImage>> GetAllCarImages();
            IDataResult<CarImage> GetCarImage(int id);
            IDataResult<List<CarImage>> GetCarImageByCarId(int carId);
      
    }
}
