using APIDashboard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIDashboard.Data
{
    public class ServerMapping : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.HasKey(server => server.Id);
            builder.Property(server => server.Name).IsRequired().HasColumnType("varchar(60)").HasMaxLength(60);
            builder.Property(server => server.IsOnline).IsRequired().HasMaxLength(6);
        }
    }
}