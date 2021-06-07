using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //ICarDal Carla ilgili veri tabanında yapılacak operasyonları içeren  interfaceler 
    //istenen operasyonlar GetById, GetAll, Add, Update, Delete
 
    public interface ICarDal:IEntityRepository<Car> //çalısma tipi car olan bir IRepository'sin 
    {

        //ürüne ait ozel sartları yazıcaz join atma urun detayı vsvs 
        List<CarDetailDto> GetCarDetails();  //ürün detaylarını getir


        
    }
}
