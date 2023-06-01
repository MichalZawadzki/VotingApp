using MediatR;

namespace VotingApp.Application.Votes.Commands.CreateVote;

public record CastVoteCommand(Guid VoterId, Guid CandidateId) : IRequest<Guid>;