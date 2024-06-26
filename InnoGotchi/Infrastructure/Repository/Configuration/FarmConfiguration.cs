﻿using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.API.Infrastructure.Repository.Configuration;

public class FarmConfiguration : IEntityTypeConfiguration<Farm>
{
    public void Configure(EntityTypeBuilder<Farm> builder)
    {
        builder.HasKey(farm => farm.FarmId);

        builder.Property(farm => farm.Name).IsRequired().HasMaxLength(50);
        builder.HasIndex(farm => farm.Name).IsUnique();

        builder.HasOne(farm => farm.User)
            .WithOne(user => user.Farm)
            .HasForeignKey<User>(user => user.FarmId);

        builder.HasMany(farm => farm.Pets)
            .WithOne(pet => pet.Farm)
            .HasForeignKey(pet => pet.FarmId);

        builder.HasMany(farm => farm.Collaborations)
            .WithOne(collaboration => collaboration.Farm);
    }
}
