using MyStory.DTOs.Dtos.UserDtos;

namespace MyStory.Service.Interfaces;

public interface IFollowService
{
    void FollowUser(int followerUserId, int followingUserId);
    void UnfollowUser(int followerUserId, int followingUserId);
    IEnumerable<UserDto> GetFollowers(int userId);
    IEnumerable<UserDto> GetFollowing(int userId);
    bool IsUserFollowing(int followerUserId, int followingUserId);
}
