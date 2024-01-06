using System.ComponentModel.DataAnnotations;

namespace MyStory.DTOs.Dtos.UserDtos;

public class LoginUserDto
{
    [Required]
    public string PhoneNumber { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}