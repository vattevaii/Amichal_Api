using Amichal.Application.Common.Interfaces.Services;

namespace Amichal.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
