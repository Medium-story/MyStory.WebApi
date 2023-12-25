using MediumStory.Domain.Entities;

namespace MyStory.Data.Interfaces;

public interface IFollowInterface
{
    void AddFollow(Follow follow);
    public void RemoveFollow(int followerUserId, int followingUserId);
    IEnumerable<User> GetFollowers(int userId);
    IEnumerable<User> GetFollowing(int userId);
    bool IsUserFollowing(int followerUserId, int followingUserId);
}