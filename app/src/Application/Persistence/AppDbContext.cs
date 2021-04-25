using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Application
{
    public class AppDbContext : DbContext
    {
        private readonly IDbContextConfigurator _configurator;

        public DbSet<Domain.Client> Clients { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IDbContextConfigurator configurator) : base(options)
        {
            _configurator = configurator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _configurator.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}