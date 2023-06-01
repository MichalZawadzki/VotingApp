using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Application.Common.Mappings;
using VotingApp.Application.Common.Models;

namespace VotingApp.Application.Voters.Queries.GetVotersWithPagination;

public class GetVotersWithPaginationQueryHandler : IRequestHandler<GetVotersWithPaginationQuery, PaginatedList<VoterDto>>
{
    private readonly IApplicationDbContext _context;

    public GetVotersWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<VoterDto>> Handle(GetVotersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Voters
            .Include(x => x.CastVotes)
            .AsNoTracking()
            .Select(x => new VoterDto(x))
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
