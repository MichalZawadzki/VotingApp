using MediatR;

namespace VotingApp.Application.Voters.Commands.CreateVoter;

public record CreateVoterCommand(string FirstName, string LastName) : IRequest<Guid>;