using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class FollowService : IFollowService
{
    public void FollowUser(int followerUserId, int followingUserId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserDto> GetFollowers(int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserDto> GetFollowing(int userId)
    {
        throw new NotImplementedException();
    }

    public bool IsUserFollowing(int followerUserId, int followingUserId)
    {
        throw new NotImplementedException();
    }

    public void UnfollowUser(int followerUserId, int followingUserId)
    {
        throw new NotImplementedException();
    }
}
