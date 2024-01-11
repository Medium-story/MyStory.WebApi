using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStory.DTOs.Dtos.UserDtos;


public class AuthServiceResponseDto
{
    public string UserId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsSucceed { get; set; }
    public string Message { get; set; } = string.Empty;
}
