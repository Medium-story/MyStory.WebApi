using MyStory.DTOs.Dtos;

namespace MyStory.DTOs.FollwDtos;

public class AddFollowDto : BaseDto
{
    public string FollowerUserId { get; set; } = string.Empty;
    public string FollowingUserId { get; set; } = string.Empty;
}
