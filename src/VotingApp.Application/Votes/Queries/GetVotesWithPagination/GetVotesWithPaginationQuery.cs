using MediatR;
using VotingApp.Application.Common.Models;

namespace VotingApp.Application.Votes.Queries.GetVotesWithPagination;

public record GetVotesWithPaginationQuery : QueryWithPagination, IRequest<PaginatedList<VoteDto>>
{
}
