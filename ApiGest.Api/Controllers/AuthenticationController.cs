namespace ApiGest.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using ApiGest.Contracts.Authentication;
using ApiGest.Application.Services.Authentication;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase {

    private readonly IAuthService _authenticationService;

    public AuthenticationController(IAuthService authenticationService){
        this._authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){
        var authResult = _authenticationService.Register(request.Firstname, request.Lastname, request.Email, request.Password);

        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.Firstname,
            authResult.user.Lastname,
            authResult.user.Email,
            authResult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        var authResult = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.Firstname,
            authResult.user.Lastname,
            authResult.user.Email,
            authResult.Token);
        return Ok(response);
    }
}