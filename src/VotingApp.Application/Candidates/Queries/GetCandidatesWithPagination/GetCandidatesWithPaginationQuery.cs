using MediatR;
using VotingApp.Application.Common.Models;

namespace VotingApp.Application.Candidates.Queries.GetCandidatesWithPagination;

public record GetCandidatesWithPaginationQuery : QueryWithPagination, IRequest<PaginatedList<CandidateDto>>
{
}
