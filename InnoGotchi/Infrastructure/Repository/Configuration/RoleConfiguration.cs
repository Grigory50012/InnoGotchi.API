using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.Infrastructure.Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.HasData(
            new {
                Id = new Guid("4ac8240a-8498-4869-bc86-60e5dc982d27"),
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}
