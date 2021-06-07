﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    //ICAR DAL YERINE CRUD islemlerini EERB den operasyonları aldık ve veritabanı operasyonlarını yazmaya hazırız 
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            //join atalım
            using (Context context = new Context())
            {
                var result = from c in context.TblCar  //arabayla
                             join color in context.TblColor on c.ColorId equals color.ColorId //renkleri ve 
                             join b in context.TblBrand on c.BrandId equals b.BrandId          // markaları join et 
                             select new CarDetailDto //hangi kolonları istiyoruz 
                             {
                                 CarId = c.CarId,
                                 ColorName = color.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                                

                             };
                return result.ToList();
            }
        }
    }
}