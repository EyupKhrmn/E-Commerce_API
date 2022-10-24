using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using ETicaretAPI.Application.Abstraction.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ETicaretAPI.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Application.DTOs.Token CreateAccessToken(int minute)
    {
        Application.DTOs.Token token = new();

        //Security keyin simetriğini alıyoruz
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SingInKey"]));
        
        //Şifrelenmiş kimliği oluşturuyoruz
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
        
        //oluşturulacak token ayarlarını veriyoruz 
        token.Expiration = DateTime.UtcNow.AddMinutes(minute);
        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials
        );
        
        
        //token oluşturucu sınıfından bir örnek alalım
        JwtSecurityTokenHandler tokenHandler = new();
       token.AccessToken = tokenHandler.WriteToken(securityToken);
       token.RefreshToken = CreateRefreshToken();
       return token;

    }

    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);

    }
}