using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApp.Domain.Entities;

namespace VotingApp.Infrastructure.Persistance.Configurations;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.Property(t => t.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(t => t.LastName)
            .HasMaxLength(50)
            .IsRequired();
    }
}
