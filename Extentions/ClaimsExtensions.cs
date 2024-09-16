using System.Security.Claims;

namespace Api.Extentions;

public static class ClaimsExtensions
{
    public static string? GetUsername(this ClaimsPrincipal user)
    {
       var claim = user.Claims
            .SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"));
            
            return claim?.Value;
    }
}