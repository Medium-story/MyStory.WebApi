using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyStory.DTOs.Dtos.UserDtos;
using MyStory.DTOs.UserRoleEnums;
using MyStory.Service.Exceptions;
using MyStory.Service.Exceptions.UserExceptions;
using MyStory.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace MyStory.Service.Services;

public class UserService(UserManager<User> userManager,
                         IConfiguration configuration) : IUserService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    #region Register qilish uchun
    public async Task<AuthServiceResponseDto> RegisterAsync(RegisterUserDto registerDto)
    {
        var FulNumber = registerDto.PhoneNumber;
        var first = FulNumber[0];
        var PhoneNumber = FulNumber.Remove(0, 1);

        if (!double.TryParse(PhoneNumber, out _))
        {
            return new AuthServiceResponseDto
            {
                IsSucceed = false,
                Message = "Phone number raqam bo'lishi kerak "
            };
        }


        var existingUser = await _userManager.FindByNameAsync(registerDto.PhoneNumber);

        if (existingUser != null)
        {
            return new AuthServiceResponseDto
            {
                IsSucceed = false,
                Message = "Phone number already exists."
            };
        }

        var newUser = new User
        {
            UserName = registerDto.PhoneNumber,
            PhoneNumber = registerDto.PhoneNumber,
            FullName = registerDto.FullName,
            PhoneNumberConfirmed = true,

            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var createUserResult = await _userManager.CreateAsync(newUser, registerDto.Password);

        if (!createUserResult.Succeeded)
        {
            var errorString = "User creation failed because: " + string.Join(" ", createUserResult.Errors.Select(e => e.Description));

            return new AuthServiceResponseDto
            {
                IsSucceed = false,
                Message = errorString
            };
        }

        if (Enum.TryParse(registerDto.userRoles.ToString(), true, out UserRoles userRole))
        {
            string roleName = userRole.ToString();
            await _userManager.AddToRoleAsync(newUser, roleName);
        }
        else
        {
            return new AuthServiceResponseDto
            {
                IsSucceed = false,
                Message = $"Invalid role: {registerDto.userRoles}"
            };
        }

        return new AuthServiceResponseDto
        {
            IsSucceed = true,
            Message = "User created successfully."
        };
    }

    #endregion


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
            UserId = user.Id,
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

    public async Task ChangePasswordAsync(ChangePasswordDto dto)
    {
        if (dto is null)
        {
            throw new UserBadRequestException(nameof(dto));
        }

        var user = await _userManager.FindByNameAsync(dto.PhoneNumber);
        if (user is null)
        {
            throw new UserBadRequestException("User not found");
        }

        var resul = await _userManager.ChangePasswordAsync(user,
                                                      dto.OldPassword,
                                                      dto.NewPassword);
        if (!resul.Succeeded)
        {
            throw new UserBadRequestException("Failed to change password");
        }
    }
}
