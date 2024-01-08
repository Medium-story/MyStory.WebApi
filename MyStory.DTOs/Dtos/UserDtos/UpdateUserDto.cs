using System.ComponentModel.DataAnnotations;

namespace MyStory.DTOs.Dtos.UserDtos;

public class UpdateUserDto : BaseDto
{
    public string FullName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string LinkedIn { get; set; } = string.Empty;
    public string GitHub { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
