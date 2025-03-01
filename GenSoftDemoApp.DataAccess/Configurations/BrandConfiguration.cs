using GenSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenSoftDemoApp.DataAccess.Configurations
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
