using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
      
       
    }
}
