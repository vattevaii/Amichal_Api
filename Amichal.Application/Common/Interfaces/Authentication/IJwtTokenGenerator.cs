using Amichal.Domain.Entities;

namespace Amichal.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
