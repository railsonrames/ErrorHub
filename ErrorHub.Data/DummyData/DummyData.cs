using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Enuns;
using Microsoft.EntityFrameworkCore;
using System;

namespace ErrorHub.Data.DummyData
{
    public static class DummyData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorOccurrence>().HasData(
                new ErrorOccurrence
                {
                    Id = 1,
                    Level = LevelOccurrence.Error,
                    Environment = EnvironmentOccurrence.Staging,
                    Title = "Database unreachable.",
                    Description = "Connection string is null or empty.",
                    ArchiviedRecord = false,
                    Origin = "Aplicação Web Master Blaster 3000 XPTO.",
                    CreatedAt = new DateTime()
                },
                new ErrorOccurrence
                {
                    Id = 2,
                    Level = LevelOccurrence.Error,
                    Environment = EnvironmentOccurrence.Development,
                    Title = "Organic Metabots Error Power Rangers Mega Man Eletric DEFCON Database Release Exception Entity Collection",
                    Description = "Nullam velit dui, semper et, lacinia vitae, sodales at, velit.",
                    ArchiviedRecord = true,
                    Origin = "Posuere Enim Incorporated",
                    CreatedAt = new DateTime(2020, 8, 12)
                }
                );
        }
    }
}
