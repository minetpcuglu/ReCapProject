using Core.Entities.Concrete;
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

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RKDCHFH;Database=Db.ReCapProject;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarImage>().HasKey(x=>x.CarImagesId);
        }

        //hangi nesnem hangi nesneye karsı gelcek 
        public DbSet<Car> TblCar { get; set; }
        public DbSet<Brand> TblBrand { get; set; }
        public DbSet<Color> TblColor { get; set; }
        public DbSet<User> TblUser { get; set; }
        public DbSet<OperationClaims> TblOperationClaims { get; set; }
        public DbSet<UserOperationClaims> TblUserOperationClaims { get; set; }
        public DbSet<Rental> TblRental { get; set; }
        public DbSet<Customer> TblCustomer { get; set; }
        public DbSet<CarImage> TblcarImages { get; set; }

    }
}
