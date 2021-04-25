using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IDbContextModelConfigurator
    {
        public void Configure(ModelBuilder builder);
    }
}