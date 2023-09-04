using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities;
using ErrorOr;

namespace Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.FindByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        var user = _userRepository.FindByEmail(email);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!user.Password.Equals(password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}