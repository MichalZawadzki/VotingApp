using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Application.Common.Mappings;
using VotingApp.Application.Common.Models;

namespace VotingApp.Application.Votes.Queries.GetVotesWithPagination;

public class GetVotesWithPaginationQueryHandler : IRequestHandler<GetVotesWithPaginationQuery, PaginatedList<VoteDto>>
{
    private readonly IApplicationDbContext _context;

    public GetVotesWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<VoteDto>> Handle(GetVotesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Votes
            .Include(x => x.Voter)
            .Include(x => x.Candidate)
            .AsNoTracking()
            .Select(x => new VoteDto(x))
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
