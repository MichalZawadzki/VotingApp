using FluentValidation;

namespace VotingApp.Application.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
{
    public CreateCandidateCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(v => v.LastName)
            .MaximumLength(50)
            .NotEmpty();
    }
}
