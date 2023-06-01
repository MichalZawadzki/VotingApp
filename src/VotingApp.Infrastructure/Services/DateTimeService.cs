using VotingApp.Application.Common.Interfaces;

namespace VotingApp.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
