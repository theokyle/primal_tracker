using System;
using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetId(this ClaimsPrincipal user)
    {
        string idValue = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("User ID claim missing");

        if (!Guid.TryParse(idValue, out var userId))
            throw new UnauthorizedAccessException("Invalid user ID in token");
        
        return userId;
    }
}
