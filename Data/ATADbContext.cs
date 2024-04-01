using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATA.Models;
using Microsoft.EntityFrameworkCore;

namespace ATA.Data
{
    public class ATADbContext: DbContext
    {
        public ATADbContext(DbContextOptions options) : base(options){}

        public DbSet<Admin> Admins {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Booking> Bookings {get; set;}
        public DbSet<Driver> Drivers {get; set;}
        public DbSet<Models.Route> Routes {get; set;}
        public DbSet<Vehicle> Vehicles {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                        .Property(c => c.DOB)
                        .HasColumnType("DATE");

            modelBuilder.Entity<Customer>()
                .HasIndex(u => u.CustomerMail)
                .IsUnique();
        }
    }

}