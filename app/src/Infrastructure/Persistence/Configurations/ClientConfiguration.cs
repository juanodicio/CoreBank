using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration: IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.Property(t => t.Id)
                .HasColumnName("id");
            
            builder.Property(t => t.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(70)")
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            builder.Property(t => t.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }
    }
}