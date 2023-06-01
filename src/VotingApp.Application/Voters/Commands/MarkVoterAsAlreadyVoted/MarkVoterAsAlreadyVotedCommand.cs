using MediatR;

namespace VotingApp.Application.Voters.Commands.MarkVoterAsAlreadyVoted;

public record MarkVoterAsAlreadyVotedCommand(Guid VoterId) : IRequest;