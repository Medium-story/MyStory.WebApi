﻿namespace MyStory.DTOs.Dtos.LikeDtos;

public class AddLikeDto
{
    public int CommentId { get; set; }
    public string UserId { get; set; } = string.Empty;

}
