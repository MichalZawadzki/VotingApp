using Microsoft.EntityFrameworkCore;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Voter> Voters { get; }
    DbSet<Vote> Votes { get; }
    DbSet<Candidate> Candidates { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
