using ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Features.Commads.AppUser.LoginUser;

public class LoginUserCommandResponse
{ 
    
}

public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
{
    public Token Token { get; set; }
}

public class LoginUserErrorCommandResponse : LoginUserCommandResponse
{
    public string Message { get; set; }
}