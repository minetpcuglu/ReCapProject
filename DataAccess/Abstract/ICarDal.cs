using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //ICarDal Carla ilgili veri tabanında yapılacak operasyonları içeren  interfaceler 
    //istenen operasyonlar GetById, GetAll, Add, Update, Delete
 
    public interface ICarDal
    {
        List<Car> GetAll();     //Baska bir katmanı kullanmak ıstıyorsak(Entities) referans veririz 
        List<Car> GetByCarId( int BrandId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);


        
    }
}
