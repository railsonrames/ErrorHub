using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorHub.Data.Context.EntitieMapping
{
    public class ErrorOccurrenceMapping : IEntityTypeConfiguration<ErrorOccurrence>
    {
        public void Configure(EntityTypeBuilder<ErrorOccurrence> builder)
        {
            builder.ToTable(SnakeCase.Convert(nameof(ErrorOccurrence)));
            builder.HasKey(x => x.Id)
                .HasName("error_occurrence_id");
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(x => x.Level)
                .HasColumnName("level")
                .IsRequired();
            builder.Property(x => x.Environment)
                .HasColumnName("environment")
                .IsRequired();
            builder.Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired();
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();
            builder.Property(x => x.ArchiviedRecord)
                .HasColumnName("archivied_record")
                .IsRequired();
            builder.Property(x => x.Origin)
                .HasColumnName("origin")
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
