using Bogus;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=>x.Title).HasColumnType("nvarchar(100)");   
            builder.Property(x=>x.ImageUrl).HasColumnType("nvarchar(256)");   
            builder.Property(x=>x.Price).HasColumnType("decimal(18,2)"); 
        }
    }
}
