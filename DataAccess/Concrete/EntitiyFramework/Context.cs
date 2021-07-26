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

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RQ8KHFA;Database=Db_ReCapProject;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarImage>().HasKey(x=>x.CarImagesId);
        }

        //hangi nesnem hangi nesneye karsı gelcek 
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

    }
}
