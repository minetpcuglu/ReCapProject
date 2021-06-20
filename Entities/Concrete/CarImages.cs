using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImages : IEntity
    {
        //Id,CarId,ImagePath,Date
        public int CarImagesId { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
    }
}
