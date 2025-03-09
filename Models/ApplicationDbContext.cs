using Microsoft.EntityFrameworkCore;
using ELNET01.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;



namespace ELNET01.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "Server=127.0.0.1;Port=3306;Database=hotel;User=root;Password=;",
                    ServerVersion.AutoDetect("Server=127.0.0.1;Port=3306;Database=hotel;User=root;Password=;") // Auto-detect MySQL version
                );
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
