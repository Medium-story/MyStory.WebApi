﻿namespace MediumStory.Domain.Entities;

public class Reply : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public int ArticleId { get; set; }
    public Article Article { get; set; } = new();
    public User User { get; set; } = new();
    public Comment Comment { get; set; } = new();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public DateTime CreatedAt { get; set; }
}
