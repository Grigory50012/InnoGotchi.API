using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.API.Infrastructure.Repository.Configuration
{
    public class CollaborationsConfiguration : IEntityTypeConfiguration<Collaboration>
    {
        public void Configure(EntityTypeBuilder<Collaboration> builder)
        {
            builder.HasKey(c => new {c.UserId, c.FarmId});

            builder.HasOne(x => x.User)
                .WithMany(x => x.Collaborations)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Farm)
                .WithMany(x => x.Collaborations)
                .HasForeignKey(x => x.FarmId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
