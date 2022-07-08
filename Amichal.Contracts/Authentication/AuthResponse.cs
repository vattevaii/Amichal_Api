namespace Amichal.Contracts.Authentication;
public record AuthResponse(
   Guid id,
   string FirstName,
   string LastName,
   string Token
);