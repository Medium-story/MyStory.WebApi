using MyStory.DTOs.Dtos.UserDtos;

namespace MyStory.Service.Interfaces;

public interface IUserService
{
    Task<AuthServiceResponseDto> RegisterAsync(RegisterUserDto registerDto);
    Task<LoginResultDto> LoginAsync(LoginUserDto dto);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetByIdUserAsync(string id);
    Task ChangePasswordAsync(ChangePasswordDto dto);
    Task Logout(LogoutUser logoutUser);
    Task DeleteAccountAsync(LoginUserDto loginUser);
}