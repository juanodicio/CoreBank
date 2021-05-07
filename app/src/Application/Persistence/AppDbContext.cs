using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;

namespace Application.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IDbContextModelConfigurator _modelConfigurator;

        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IDbContextModelConfigurator modelConfigurator) : base(options)
        {
            _modelConfigurator = modelConfigurator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _modelConfigurator.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}