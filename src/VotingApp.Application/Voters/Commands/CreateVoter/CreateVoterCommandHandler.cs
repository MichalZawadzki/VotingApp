using MediatR;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Domain.Entities;
using VotingApp.Domain.Events;

namespace VotingApp.Application.Voters.Commands.CreateVoter;

public class CreateCandidateCommandHandler : IRequestHandler<CreateVoterCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCandidateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateVoterCommand request, CancellationToken cancellationToken)
    {
        var entity = Voter.Create(request.FirstName, request.LastName);

        entity.AddDomainEvent(new VoterCreatedEvent(entity));

        _context.Voters.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
