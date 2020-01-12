using APIDashboard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIDashboard.Data.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("varchar(60)").HasMaxLength(60);
            builder.Property(c => c.Email).IsRequired().HasColumnType("varchar(60)").HasMaxLength(80);
            builder.Property(c => c.State).IsRequired().HasColumnType("varchar(60)").HasMaxLength(80);
            builder.HasMany(c => c.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);
        }
    }
}