using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Domain.Entities;

namespace VotingApp.Infrastructure.Persistance.Configurations;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder
            .HasOne(b => b.Voter)
            .WithMany(e => e.CastVotes)
            .HasForeignKey(e => e.VoterId)
            .IsRequired();

        builder
            .HasOne(b => b.Candidate)
            .WithMany(e => e.ObtainedVotes)
            .HasForeignKey(e => e.CandidateId)
            .IsRequired();
    }
}
