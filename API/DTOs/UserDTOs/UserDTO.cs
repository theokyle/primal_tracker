using System;

namespace Api.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }    
    public required string Email { get; set; }
    public string? ImageUrl { get; set; }
    public required string Token { get; set; }
}
