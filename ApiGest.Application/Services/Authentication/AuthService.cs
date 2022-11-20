namespace ApiGest.Application.Services.Authentication;

using ApiGest.Application.Common.Interfaces.Authentication;
using ApiGest.Application.Common.Interfaces.Persistance;
using ApiGest.Domain.Entities;


public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        this._jwtTokenGenerator = jwtTokenGenerator;
        this._userRepository = userRepository;
    }

    public AuthResult Login(string email, string password)
    {
        // Validate the user does exists
        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new Exception("User does not exists");
        }

        // Validate the password is correct
        if(user.Password != password){
            throw new Exception("Password is incorrect");
        }
        // Generate the JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }

    public AuthResult Register(string firstname, string lastname, string email, string password)
    {
        // Validate the user does not exists
        if(_userRepository.GetUserByEmail(email) is not null){
            throw new Exception("User already exists");
        }

        // Create user (generate unique Id) and persist it
        var user = new User()
        {
            Firstname = firstname,
            Lastname = lastname,
            Email = email,
            Password = password,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }
}