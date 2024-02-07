using LegoCollectionCalculator2._0.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegoCollectionCalculator2._0.Server.Entities.Config
{
    public class ThemeEntityConfig : IEntityTypeConfiguration<ThemeDbo>
    {
        public void Configure(EntityTypeBuilder<ThemeDbo> builder)
        {
            builder.ToTable("Themes", CollectionContext.DEFAULTSCHEMA);
            builder.HasKey(x => x.ThemeID);
            builder.Property(x => x.ThemeID).HasColumnName("ThemeID");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.CollectionID).HasColumnName("CollectionID");
        }
    }
}
