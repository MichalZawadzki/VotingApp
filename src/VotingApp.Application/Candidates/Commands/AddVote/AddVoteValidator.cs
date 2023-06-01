using FluentValidation;

namespace VotingApp.Application.Candidates.Commands.AddVote;

public class AddVoteValidator : AbstractValidator<AddVoteCommand>
{
    public AddVoteValidator()
    {
        RuleFor(v => v.CandidateId)
            .NotEmpty();
    }
}