using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorHub.Data.Context.EntitieMapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(SnakeCase.Convert(nameof(User)));
            builder.HasKey(x => x.Id)
                .HasName("user_id");
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();
            builder.Property(x => x.Password)
                .HasColumnName("hash_password")
                .IsRequired();
        }
    }
}
