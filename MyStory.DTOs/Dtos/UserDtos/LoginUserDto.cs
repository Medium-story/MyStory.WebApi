using System.ComponentModel.DataAnnotations;

namespace MyStory.DTOs.Dtos.UserDtos;

public class LoginUserDto
{
    [Required]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
