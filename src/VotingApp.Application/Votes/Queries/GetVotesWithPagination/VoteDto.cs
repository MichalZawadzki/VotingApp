using VotingApp.Domain.Entities;

namespace VotingApp.Application.Votes.Queries.GetVotesWithPagination;

public class VoteDto
{
    public string VoterFirstName { get; }

    public string VoterLastName { get; }


    public string CandidateFirstName { get; }

    public string CandidateLastName { get; }

    public DateTime VotedAt { get; }

    public VoteDto(Vote vote)
    {
        VoterFirstName = vote.Voter.FirstName;
        VoterLastName = vote.Voter.LastName;
        CandidateFirstName = vote.Candidate.FirstName;
        CandidateLastName = vote.Candidate.LastName;
        VotedAt = vote.Created;
    }
}
