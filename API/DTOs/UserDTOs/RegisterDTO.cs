using System;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs;

public class RegisterDTO
{
    [Required]
    public string UserName { get; set; } = "";
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    [Required]
    [MinLength(4)]
    public string Password { get; set; } = "";
}
