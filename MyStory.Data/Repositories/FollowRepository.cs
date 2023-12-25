using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class FollowRepository(AppDbContext appDb) : IFollowInterface
{
    private readonly AppDbContext _dbContext = appDb;

    public void AddFollow(Follow follow)
    {
        _dbContext.Follows.Add(follow);
    }

    public void RemoveFollow(int followerUserId, int followingUserId)
    {
        var follow = _dbContext.Follows
            .FirstOrDefault(f => f.FollowerUserId == followerUserId.ToString() && f.FollowingUserId == followingUserId.ToString());

        if (follow != null)
        {
            _dbContext.Follows.Remove(follow);
        }
    }

    public IEnumerable<User> GetFollowers(int userId)
    {
        return _dbContext.Follows
            .Where(f => f.FollowingUserId == userId.ToString())
            .Select(f => f.FollowerUser)
            .ToList();
    }

    public IEnumerable<User> GetFollowing(int userId)
    {
        return _dbContext.Follows
            .Where(f => f.FollowerUserId == userId.ToString())
            .Select(f => f.FollowingUser)
            .ToList();
    }

    public bool IsUserFollowing(int followerUserId, int followingUserId)
    {
        return _dbContext.Follows
            .Any(f => f.FollowerUserId == followerUserId.ToString() && f.FollowingUserId == followingUserId.ToString());
    }
}
