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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Title).HasColumnType("nvarchar(100)");

            //Faker  faker=new Faker();

            //Brand brand = new(){Title = faker.Company.CompanyName().Replace(" ","")};
        }
    }
}
