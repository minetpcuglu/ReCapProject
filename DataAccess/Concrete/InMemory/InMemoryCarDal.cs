using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Bellek üzerinde Araba ile ilgili veri erişim kodlarının yazılacagı sınıf
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;  //araba listesi olusturuldu  *Global bir değişkendir genelde _cars olarak tercih edilir
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            { 
                new Car{CarId=1,BrandId=2,ColorId=3,DailyPrice=300,ModelYear="2017",Description="Otomatik vites"},
                 new Car{CarId=2,BrandId=3,ColorId=4,DailyPrice=400,ModelYear="2019",Description="Manuel"},
                  new Car{CarId=2,BrandId=4,ColorId=5,DailyPrice=500,ModelYear="2021",Description="Otomatik vites"},
            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LING Kullanalım (Language Integrated Query) Dile gömülü sorgulama.
            Car Cartodelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);   //SingleOrDefault yerine First ya da FirstOrDefault ta olur

            _cars.Remove(Cartodelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByCarId()
        {
            return _cars;
        }

        public List<Car> GetByCarId(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId ).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //LING Kullanalım (Language Integrated Query) Dile gömülü sorgulama.
            Car CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);  //Gönderilen araba ıd sine sahip olan listede ki car bul

            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
            CarToUpdate.ModelYear = car.ModelYear;
            _cars.Remove(CarToUpdate);

        }
    }
}
