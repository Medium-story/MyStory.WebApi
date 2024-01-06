using MediumStory.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyStory.DTOs.Dtos.UserDtos;

public class RegisterUserDto : LoginUserDto
{
    public string FullName { get; set; } = null!;

    public static implicit operator User(RegisterUserDto dto)
    {
        return new User
        {
            UserName = dto.PhoneNumber,
            PhoneNumber = dto.PhoneNumber,
            FullName = dto.FullName,
            PhoneNumberConfirmed = true,
        };
    }
}