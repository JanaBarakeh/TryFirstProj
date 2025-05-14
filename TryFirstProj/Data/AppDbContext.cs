using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TryFirstProj.Models;

namespace TryFirstProj.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
            
        }

        // to create a table
        public DbSet<Item> Items { get; set; }
        public DbSet<Catogrey> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catogrey>().HasData(
                new Catogrey { Id = 1, Name = "Select Catogrey" },
                new Catogrey { Id = 2, Name = "Computers" },
                new Catogrey { Id = 3, Name = "Mobiles" },
                new Catogrey { Id = 4, Name = "Farme" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
   
}
