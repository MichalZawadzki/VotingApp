using FluentValidation;

namespace VotingApp.Application.Voters.Commands.CreateVoter;

public class CreateVoterCommandValidator : AbstractValidator<CreateVoterCommand>
{
    public CreateVoterCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(v => v.LastName)
            .MaximumLength(50)
            .NotEmpty();
    }
}
