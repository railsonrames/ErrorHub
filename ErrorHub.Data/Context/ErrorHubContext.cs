using ErrorHub.Data.Context.EntitieMapping;
using ErrorHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ErrorHub.Data.Context
{
    public class ErrorHubContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorOccurrence> ErrorOccurrences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ErrorOccurrenceMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        private string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder();
            var configurationFile = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configuration.AddJsonFile(configurationFile, false);
            var configurationJson = configuration.Build();
            var connectionString = configurationJson.GetSection("AzureDataBaseConnection").Value;
            if (connectionString == null) throw new Exception("String de conexão com o banco de dados nula, verificar configuração.");
            return connectionString;
        }
    }
}
