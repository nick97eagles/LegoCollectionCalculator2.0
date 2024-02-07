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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ThemeEntityConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
