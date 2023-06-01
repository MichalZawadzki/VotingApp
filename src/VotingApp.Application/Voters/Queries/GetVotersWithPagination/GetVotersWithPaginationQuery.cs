using MediatR;
using VotingApp.Application.Common.Models;

namespace VotingApp.Application.Voters.Queries.GetVotersWithPagination;

public record GetVotersWithPaginationQuery : QueryWithPagination, IRequest<PaginatedList<VoterDto>>
{
}
