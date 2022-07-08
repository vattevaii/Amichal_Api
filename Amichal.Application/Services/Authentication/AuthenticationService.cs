using Amichal.Application.Common.Errors;
using Amichal.Application.Common.Interfaces.Authentication;
using Amichal.Application.Common.Interfaces.Services.Persistence;
using Amichal.Application.Common.Interfaces.Services.Persistence.Users;
using Amichal.Domain.Entities;
using Amichal.Domain.Entities.UserRoles;

namespace Amichal.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // validate user exists
        if (_unitOfWork.Admins.GetT(b => b.Email == email) is not User user)
        {
            throw new Exception("User with given email doesn't exists");
        }

        // authenticate user
        if (user.Password != password)
        {
            throw new Exception("Incorrect Password");
        }

        // create jwt result
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }

    public AuthenticationResult Register(string firstname, string lastName, string email, string password, string seller)
    {
        // check if user exists
        if (_unitOfWork.Admins.GetT(b => b.Email == email) is not null)
        {
            throw new DuplicateEmailException();
        }
        Roles role = (Roles)Enum.Parse(typeof(Roles), seller);
        if (!role.Equals(Roles.Seller) && !role.Equals(Roles.Buyer))
            throw new Exception("Bad Request");
        // create user (genereate unique id)
        var user = new Customer()
        {
            FirstName = firstname,
            LastName = lastName,
            Email = email,
            Password = password
        };

        //_unitOfWork.Customers.Add(user);
        // create Jwt Token

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }
}