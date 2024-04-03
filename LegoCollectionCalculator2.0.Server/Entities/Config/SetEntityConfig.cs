using LegoCollectionCalculator2._0.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegoCollectionCalculator2._0.Server.Entities.Config
{
    public class SetEntityConfig : IEntityTypeConfiguration<SetDbo>
    {
        public void Configure(EntityTypeBuilder<SetDbo> builder)
        {
            builder.ToTable("Sets", CollectionContext.DEFAULTSCHEMA);
            builder.HasKey(x => x.SetID);
        }
    }
}
