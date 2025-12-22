using System;
using MODELS.Entities;

namespace Api.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);

}
