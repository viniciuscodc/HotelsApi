using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelsApi.Data;

namespace HotelsApi.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country {
                    Id = 1,
                    Name = "Jamaica",
                    Shortname = "JM" 
                },
                new Country {
                    Id = 2,
                    Name = "Bahamas",
                    Shortname = "Bs" 
                },
                new Country {
                    Id = 3,
                    Name = "Cayman Island",
                    Shortname = "CI" 
                }
            );
        }
    }
}