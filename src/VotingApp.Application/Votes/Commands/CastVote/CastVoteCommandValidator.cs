using FluentValidation;

namespace VotingApp.Application.Votes.Commands.CreateVote
{
    public class CastVoteCommandValidator : AbstractValidator<CastVoteCommand>
    {
        public CastVoteCommandValidator()
        {
            RuleFor(v => v.CandidateId)
                .NotEmpty();

            RuleFor(v => v.VoterId)
                .NotEmpty();
        }
    }
}