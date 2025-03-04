using GenSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenSoftDemoApp.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=>x.Title).HasColumnType("nvarchar(256)");   
            builder.Property(x=>x.Price).HasColumnType("decimal(18,2)"); 
        }
    }
}
