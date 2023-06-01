using FluentValidation;

namespace VotingApp.Application.Voters.Commands.MarkVoterAsAlreadyVoted;

public class MarkVoterAsAlreadyVotedValidator : AbstractValidator<MarkVoterAsAlreadyVotedCommand>
{
    public MarkVoterAsAlreadyVotedValidator()
    {
        RuleFor(v => v.VoterId)
            .NotEmpty();
    }
}