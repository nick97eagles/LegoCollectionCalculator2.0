using LegoCollectionCalculator2._0.Server.Entities;
using LegoCollectionCalculator2._0.Server.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace LegoCollectionCalculator2._0.Server.Contexts
{
    public class UserContext : DbContext
    {
        public const string DEFAULTSCHEMA = "dbo";

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<Userdbo> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfig());   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
