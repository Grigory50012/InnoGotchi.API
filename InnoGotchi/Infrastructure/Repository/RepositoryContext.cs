﻿using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Infrastructure.Repository.Configuration;
using InnoGotchi.Core.Entities.Models;
using InnoGotchi.Infrastructure.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository;

public class RepositoryContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<BodyPart> BodyParts { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Farm> Farms { get; set; }
    public DbSet<Collaboration> Collaborations { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BodyPartConfiguration());
        modelBuilder.ApplyConfiguration(new CollaborationsConfiguration());
        modelBuilder.ApplyConfiguration(new FarmConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PetConfiguration());
    }
}
