using MyStory.DTOs.Dtos;

namespace MyStory.DTOs.FollwDtos;

public class FollowDto : BaseDto
{
    public string FollowerUserId { get; set; } = string.Empty;
    public string FollowingUserId { get; set; } = string.Empty;
}
