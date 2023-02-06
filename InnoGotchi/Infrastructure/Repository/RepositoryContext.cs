using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Infrastructure.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository
{
    public class RepositoryContext : DbContext
    {
        DbSet<BodyPart>? BodyParts { get; set; }
        DbSet<Pet>? Pets { get; set; }
        DbSet<Farm>? Farms { get; set; }
        DbSet<User>? Users { get; set; }
        DbSet<Collaboration>? Collaborations { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

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
}
