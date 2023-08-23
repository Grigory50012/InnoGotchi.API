using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.API.Infrastructure.Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(user => user.LastName).IsRequired().HasMaxLength(50);

        //builder.HasMany(user => user.Collaborations)
        //    .WithOne(collaboration => collaboration.User);

        //builder.HasOne(user => user.Farm)
        //    .WithOne(farm => farm.User)
        //    .HasForeignKey<Farm>(farm => farm.OwnerId);
    }
}
