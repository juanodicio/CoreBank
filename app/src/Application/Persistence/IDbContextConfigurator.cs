using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IDbContextConfigurator
    {
        public void Configure(ModelBuilder builder);
    }
}