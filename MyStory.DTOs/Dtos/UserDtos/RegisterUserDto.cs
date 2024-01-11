using MediumStory.Domain.Entities;
using MyStory.DTOs.UserRoleEnums;
using System.ComponentModel.DataAnnotations;

namespace MyStory.DTOs.Dtos.UserDtos;

public class RegisterUserDto : LoginUserDto
{
    public string FullName { get; set; } = null!;

    public UserRoles userRoles { get; set; }

}