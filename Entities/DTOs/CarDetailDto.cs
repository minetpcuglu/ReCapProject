using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //DTO=Data Tranformation Object
    //ilişkili veri tabanlarında ilişki isimlerine göre getirme id ye gore değil yani join işlemi
    //IEntity mirası vermiyoruz veri tabanı tablosu değil "cardetaildto"
    //IDto = evrensel bir interface
    public class CarDetailDto :IDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int  ColorId { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
