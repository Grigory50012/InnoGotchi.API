using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.API.Infrastructure.Repository.Configuration;

public class CollaborationsConfiguration : IEntityTypeConfiguration<Collaboration>
{
    public void Configure(EntityTypeBuilder<Collaboration> builder)
    {
        builder.HasKey(collaboration => new {collaboration.FarmId, collaboration.UserId});

        builder.HasOne(collaboration => collaboration.User)
            .WithMany(user => user.Collaborations)
            .HasForeignKey(collaboration => collaboration.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(collaboration => collaboration.Farm)
            .WithMany(farm => farm.Collaborations)
            .HasForeignKey(collaboration => collaboration.FarmId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
