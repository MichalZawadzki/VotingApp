using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Domain.Entities;

namespace VotingApp.Infrastructure.Persistance.Configurations;

public class VoterConfiguration : IEntityTypeConfiguration<Voter>
{
    public void Configure(EntityTypeBuilder<Voter> builder)
    {
        builder.Property(t => t.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(t => t.LastName)
            .HasMaxLength(50)
            .IsRequired();
    }
}
