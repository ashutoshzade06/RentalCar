using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Car_RentalDbContext : DbContext
    {
        public Car_RentalDbContext()
        {
        }

        public Car_RentalDbContext(DbContextOptions<Car_RentalDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Rented_Car> Rented_Cars { get; set; }
    }
}
