namespace ETicaretAPI.Application.Abstraction.Services;

public interface IAutService
{ 
    Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
}