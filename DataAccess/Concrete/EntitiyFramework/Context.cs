using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Concrete.EntitiyFramework
{
    public class Context:DbContext
    {
        // projem hangi veri tabanı ile ilişkili oldugunu belirtilen yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RKDCHFH;Database=Db_ReCapProject;Trusted_Connection=true");
        }

        //hangi nesnem hangi nesneye karsı gelcek 
        public DbSet<Car> TblCar { get; set; }
        public DbSet<Brand> TblBrand { get; set; }
        public DbSet<Color> TblColor { get; set; }

    }
}
