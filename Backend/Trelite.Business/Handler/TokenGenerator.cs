using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Trelite.Data.Models;

namespace Trelite.Business.Handler;

public class TokenGenerator
{
    protected readonly IConfiguration _config;
    public TokenGenerator(IConfiguration config)
    {
        _config = config;
    }
    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.Role,user.Role.Name)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer:_config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires:DateTime.Now.AddHours(1),
            signingCredentials:creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
