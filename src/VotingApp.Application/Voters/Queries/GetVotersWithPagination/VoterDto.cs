using VotingApp.Application.Common.Mappings;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Voters.Queries.GetVotersWithPagination;

public class VoterDto : IMapFrom<Voter>
{
    public Guid Id { get; init; }

    public string FirstName { get; init; }

    public string Lastname { get; init; }

    public bool HasAlreadyVoted { get; init; }

    public VoterDto(Voter voter)
    {
        Id = voter.Id;
        FirstName = voter.FirstName;
        Lastname = voter.LastName;
        HasAlreadyVoted = voter.HasAlreadyVoted;
    }
}
