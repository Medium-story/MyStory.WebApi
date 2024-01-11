using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStory.Domain.Entities;

namespace MediumStory.Data.DataContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Article> Savedes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> CommentLikes { get; set; }
    public DbSet<ReplyLike> ReplyLikes { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Reply> Replies { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Follow> Follows { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        ConfigureArticle(builder);
        ConfigureComment(builder);
        ConfigureReply(builder);
        ConfigureFollow(builder);
        ConfigureUser(builder);


        base.OnModelCreating(builder);
    }

    private void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                    .HasMany(i => i.Articles)
                    .WithOne(a => a.User)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.ClientCascade);
    }

    private void ConfigureFollow(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Follow>()
        .HasKey(f => f.Id);

        modelBuilder.Entity<Follow>()
            .HasOne(f => f.FollowerUser)
            .WithMany(u => u.Followers)
            .HasForeignKey(f => f.FollowerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Follow>()
            .HasOne(f => f.FollowingUser)
            .WithMany(u => u.Following)
            .HasForeignKey(f => f.FollowingUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureArticle(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
                    .HasMany(i => i.Comments)
                    .WithOne(i => i.Article)
                    .HasForeignKey(i => i.ArticleId)
                    .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<Article>()
                    .HasMany(i => i.Reactions)
                    .WithOne(i => i.Article)
                    .HasForeignKey(i => i.ArticleId)
                    .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<Article>()
                    .HasMany(a => a.Users)
                    .WithMany(u => u.Saved)
                    .UsingEntity(c => c.ToTable("SavedArticles"));

    }

    private void ConfigureComment(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
                    .HasMany(i => i.Replies)
                    .WithOne(i => i.Comment)
                    .HasForeignKey(i => i.CommentId)
                    .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<Comment>()
                    .HasMany(i => i.CommentLikes)
                    .WithOne(i => i.Comment)
                    .HasForeignKey(i => i.CommentId)
                    .OnDelete(DeleteBehavior.ClientCascade); // Change to Restrict to avoid multiple cascade paths
    }

    private void ConfigureReply(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reply>()
                    .HasMany(i => i.ReplyLikes)
                    .WithOne(i => i.Reply)
                    .HasForeignKey(i => i.ReplyId)
                    .OnDelete(DeleteBehavior.ClientCascade);
    }
}
