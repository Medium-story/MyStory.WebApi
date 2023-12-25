using System.ComponentModel.DataAnnotations;

namespace MyStory.DTOs.Dtos.UserDtos;

public class AddUserDto
{
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string EmailAddress { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
