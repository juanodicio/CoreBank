using Microsoft.EntityFrameworkCore;
using Domain;

namespace Application.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IDbContextModelConfigurator _modelConfigurator;

        public DbSet<Client> Clients { get; set; }

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