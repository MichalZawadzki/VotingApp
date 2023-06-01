using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Common.Models;
using VotingApp.Application.Voters.Commands.CreateVoter;
using VotingApp.Application.Voters.Queries.GetVotersWithPagination;

namespace VotingApp.API.Controllers;

public class VotersController : ApiControllerBase
{

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateVoterCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<VoterDto>>> GetVotersWithPagination([FromQuery] GetVotersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}