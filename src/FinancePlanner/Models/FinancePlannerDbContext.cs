using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.ConfigurationModel;

namespace FinancePlanner.Models
{
    public class FinancePlannerDbContext : DbContext
    {
        private static bool _created = false;

        public FinancePlannerDbContext()
        {
            if (!_created)
            {
                this.Database.EnsureCreated();
                _created = true;
            }
        }

        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet5-FinancePlanner-ce0f4a5d-e082-4232-aa9a-a3069222ea31;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
