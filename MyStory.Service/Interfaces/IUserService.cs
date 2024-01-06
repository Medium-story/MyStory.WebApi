using MyStory.DTOs.Dtos.UserDtos;

namespace MyStory.Service.Interfaces;

public interface IUserService
{
    Task RegisterAsync(RegisterUserDto dto);
    Task<LoginResultDto> LoginAsync(LoginUserDto dto);
}