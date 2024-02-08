using LegoCollectionCalculator2._0.Server.Entities;
using LegoCollectionCalculator2._0.Server.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace LegoCollectionCalculator2._0.Server.Contexts
{
    public class CollectionContext : DbContext
    {
        public const string DEFAULTSCHEMA = "dbo";

        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options)
        {
        }

        public DbSet<ThemeDbo> Themes { get; set; }

        public DbSet<SetDbo> Sets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ThemeEntityConfig());
            modelBuilder.ApplyConfiguration(new  SetEntityConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
