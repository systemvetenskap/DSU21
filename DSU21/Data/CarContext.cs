using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSU21.Models;
using Microsoft.EntityFrameworkCore;

namespace DSU21.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options): base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CarRegister> CarRegisters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // byt namn till singular
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<CarRegister>().ToTable("Carregister");

            modelBuilder.Entity<CarRegister>()
                .HasKey(t => new { t.CarID, t.PersonID });

            modelBuilder.Entity<CarRegister>()
                .HasOne(c => c.Car)
                .WithMany(c => c.RegistryEntries)
                .HasForeignKey(c => c.CarID);

            modelBuilder.Entity<CarRegister>()
                .HasOne (p => p.Person)
                .WithMany(r => r.RegistryEntries)
                .HasForeignKey(p => p.PersonID);
            
        }

    }
}
