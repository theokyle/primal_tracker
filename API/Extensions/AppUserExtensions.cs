using System;
using Api.DTOs;
using Api.Interfaces;
using Microsoft.Build.Tasks;
using MODELS.Entities;

namespace Api.Extensions;

public static class AppUserExtensions
{
    public static UserDTO ToDTO(this User user, ITokenService tokenService)
    {
        return new UserDTO
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            ImageUrl = user.ImageUrl,
            Token = tokenService.CreateToken(user)
        };
    }
}
