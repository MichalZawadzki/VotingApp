using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Candidates.Commands.CreateCandidate;
using VotingApp.Application.Candidates.Queries.GetCandidatesWithPagination;
using VotingApp.Application.Common.Models;

namespace VotingApp.API.Controllers;

public class CandidatesController : ApiControllerBase
{

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateCandidateCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CandidateDto>>> GetCandidatesWithPagination([FromQuery] GetCandidatesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}
