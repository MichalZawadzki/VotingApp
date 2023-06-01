using MediatR;

namespace VotingApp.Application.Candidates.Commands.CreateCandidate;

public record CreateCandidateCommand(string FirstName, string LastName) : IRequest<Guid>;