using VotingApp.Application.Common.Mappings;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Candidates.Queries.GetCandidatesWithPagination;

public class CandidateDto
{
    public Guid Id { get; }

    public string FirstName { get; }

    public string Lastname { get; }

    public int VotesNumber { get; }

    public CandidateDto(Candidate candidate)
    {
        Id = candidate.Id;
        FirstName = candidate.FirstName;
        Lastname = candidate.LastName;
        VotesNumber = candidate.VotesNumber;
    }
}
