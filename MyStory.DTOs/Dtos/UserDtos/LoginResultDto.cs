﻿using MediumStory.Domain.Entities;

namespace MyStory.DTOs.Dtos.UserDtos;

public class LoginResultDto
{
    public string UserId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpireAt { get; set; }

}
