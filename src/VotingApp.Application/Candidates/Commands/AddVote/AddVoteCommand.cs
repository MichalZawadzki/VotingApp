using MediatR;

namespace VotingApp.Application.Candidates.Commands.AddVote;

public record AddVoteCommand(Guid CandidateId) : IRequest;