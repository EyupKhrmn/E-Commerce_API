namespace ETicaretAPI.Application.Abstraction.Token;

public interface ITokenHandler
{
    DTOs.Token CreateAccessToken(int minute);
}