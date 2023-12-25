using MyStory.DTOs.Dtos;

namespace MyStory.DTOs.FollwDtos;

public class UpdateFollowDto : BaseDto
{
    public string FollowerUserId { get; set; } = string.Empty;
    public string FollowingUserId { get; set; } = string.Empty;
}
