using FluentValidation;
using VotingApp.Application.Candidates.Queries.GetCandidatesWithPagination;

namespace VotingApp.Application.Voters.Queries.GetVotersWithPagination;

public class GetVotersWithPaginationQueryValidator : AbstractValidator<GetCandidatesWithPaginationQuery>
{
    public GetVotersWithPaginationQueryValidator()
    {

    }
}
