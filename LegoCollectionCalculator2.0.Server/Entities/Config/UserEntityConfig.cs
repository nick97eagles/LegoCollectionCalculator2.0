using LegoCollectionCalculator2._0.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegoCollectionCalculator2._0.Server.Entities.Config
{
    public class UserEntityConfig : IEntityTypeConfiguration<Userdbo>
    {
        public void Configure(EntityTypeBuilder<Userdbo> builder)
        {
            builder.ToTable("Users", UserContext.DEFAULTSCHEMA);
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserID).HasColumnName("UserID");
            builder.Property(x => x.UserName).HasColumnName("UserName");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.CollectionID).HasColumnName("CollectionID");
            builder.Property(x => x.UserRole).HasColumnName("UserRole");
        }
    }
}
