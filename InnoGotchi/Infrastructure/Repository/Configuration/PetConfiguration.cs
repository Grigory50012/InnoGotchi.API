using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.API.Infrastructure.Repository.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(pet => pet.PetId);

        builder.Property(pet => pet.Name).IsRequired().HasMaxLength(50);
        builder.HasIndex(pet => pet.Name).IsUnique();

        builder.HasMany(pet => pet.BodyParts)
            .WithMany(bodyPart => bodyPart.Pets);
    }
}
