using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Models;

namespace MyProject.Data
{
    public class Context : DbContext
    {
        public DbSet<Models.Car> Cars { get; set; }
        public DbSet<Models.Garage> Garages {get; set;}
        public DbSet<Models.SalesBalance> SalesBalances {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=csharpcarsmanager;user=root;password=Wheniparkmyrr_1234";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
