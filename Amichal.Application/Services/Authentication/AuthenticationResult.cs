using Amichal.Domain.Entities;

namespace Amichal.Application.Services.Authentication;
public record AuthenticationResult(
   User user,
   string Token
);