using FluentValidation;
using VotingApp.Application.Candidates.Queries.GetCandidatesWithPagination;

namespace VotingApp.Application.Votes.Queries.GetVotesWithPagination;

public class GetVotersWithPaginationQueryValidator : AbstractValidator<GetCandidatesWithPaginationQuery>
{
    public GetVotersWithPaginationQueryValidator()
    {

    }
}
