using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Common.Models;
using VotingApp.Application.Votes.Commands.CreateVote;
using VotingApp.Application.Votes.Queries.GetVotesWithPagination;

namespace VotingApp.API.Controllers;

public class VotesController : ApiControllerBase
{

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CastVoteCommand command)
    {
        return await Mediator.Send(command);
    }


    [HttpGet]
    public async Task<ActionResult<PaginatedList<VoteDto>>> GetVotesWithPagination([FromQuery] GetVotesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

}