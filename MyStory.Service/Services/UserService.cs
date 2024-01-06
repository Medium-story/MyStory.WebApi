using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyStory.DTOs.Dtos.UserDtos;
using MyStory.Service.Exceptions.UserExceptions;
using MyStory.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyStory.Service.Services;

public class UserService(UserManager<User> userManager,
                         IConfiguration configuration) : IUserService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task RegisterAsync(RegisterUserDto dto)
    {
        if (dto == null)
        {
            throw new UserNullException();
        }

        var user = (User)dto;
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new UserBadRequestException();
        }

        await _userManager.AddToRoleAsync(user, "User");
    }

    public async Task<LoginResultDto> LoginAsync(LoginUserDto dto)
    {
        if (dto == null)
        {
            throw new UserNullException();
        }
        var user = await _userManager.FindByNameAsync(dto.PhoneNumber);
        if (user == null)
        {
            throw new UserNotFoundException("User not found!");
        }

        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!result)
        {
            throw new UserBadRequestException("Password is incorrect!");
        }

        var roles = await _userManager.GetRolesAsync(user);
        string token = GenerateToken(user, roles);

        return new LoginResultDto()
        {
            PhoneNumber = user.PhoneNumber!,
            ExpireAt = DateTime.UtcNow.AddDays(1),
            FullName = user.FullName!,
            Token = token,
        };
    }

    private string GenerateToken(User user, IList<string> roles)
    {
        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]!);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.GivenName, user.FullName!),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            }),
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        foreach (var role in roles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
