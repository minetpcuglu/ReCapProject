using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class CarManager : ICarService  
    {
        ICarDal _carDal;  //injektion yapısı
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()  
        {
            //İş kodları yazılır
            return _carDal.GetAll();
        }
    }
}
