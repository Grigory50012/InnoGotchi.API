using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.Configuration;

public class BodyPartConfiguration : IEntityTypeConfiguration<BodyPart>
{
    public void Configure(EntityTypeBuilder<BodyPart> builder)  
    {
        builder.HasKey(bodyPart => bodyPart.BodyPartId);

        builder.Property(bodyPart => bodyPart.Name).IsRequired();

        builder.Property(bodyPart => bodyPart.ImageUrl).IsRequired();

        builder.HasMany(bodyPart => bodyPart.Pets)
            .WithMany(pet => pet.BodyParts);
    }
}
