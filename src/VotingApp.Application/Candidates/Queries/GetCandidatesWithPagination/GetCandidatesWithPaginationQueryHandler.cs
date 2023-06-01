using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Application.Common.Mappings;
using VotingApp.Application.Common.Models;

namespace VotingApp.Application.Candidates.Queries.GetCandidatesWithPagination;

public class GetCandidatesWithPaginationQueryHandler : IRequestHandler<GetCandidatesWithPaginationQuery, PaginatedList<CandidateDto>>
{
    private readonly IApplicationDbContext _context;

    public GetCandidatesWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<CandidateDto>> Handle(GetCandidatesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Candidates
            .AsNoTracking()
            .OrderBy(x => x.VotesNumber)
            .Select(x => new CandidateDto(x))
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
