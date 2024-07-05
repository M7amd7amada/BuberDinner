using BubberDinner.Application.Common.Interfaces.Authentication;

namespace BubberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator _jwtTokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult
        (
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            email,
            password
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult
        (
            userId,
            firstName,
            lastName,
            email,
            token
        );
    }
}