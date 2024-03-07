using MadiPets.Models;
using Microsoft.EntityFrameworkCore;

namespace MadiPets.Db
{
    public class MadiPetsDbContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Types> Types { get; set; } 
        public DbSet<Pets> Pets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer("Server=DESKTOP-OHIKMA8\\SQLEXPRESS;Database=MadiPetsDb2;Trusted_Connection=True;TrustServerCertificate=True\r\n");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Types>().HasData(
                new Types() { TypeId = 1, Type = "Куче" },
                new Types() { TypeId = 2, Type = "Котка" },
                new Types() { TypeId = 3, Type = "Хамстер" },
                new Types() { TypeId = 4, Type = "Морско свинче" },
                new Types() { TypeId = 5, Type = "Папагал" }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users() { UserId = 1, Email = "admin", Username = "admin", Password = "admin", Address="admin" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
