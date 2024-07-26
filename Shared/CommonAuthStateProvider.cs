using MedbaseLibrary.Helpers;
using MedbaseLibrary.MsalClient;
using MedbaseLibrary.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace MedbaseComponents.Shared;

public class CommonAuthStateProvider : AuthenticationStateProvider
{
    private IAuthMemory authMemory;
    public CommonAuthStateProvider(IAuthMemory auth)
    {
        authMemory = auth;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string token = "";
        AuthenticationState result = new(new ClaimsPrincipal(new ClaimsIdentity()));
        try
        {
            //token = authMemory.GetToken().Result;
            if (string.IsNullOrEmpty(token))
            {
                return result;
            }
            else
            {
                result = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(TokenToClaims(token), "JwtBearer")));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return result;
    }

    private IEnumerable<Claim> TokenToClaims(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtSecurityToken;

        jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var claims = jwtSecurityToken.Claims;

        return claims;
    }

    public void MarkUserAsAuthenticated(string token)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(TokenToClaims(token), "JwtBearer"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);

    }

    public void NotifyUserAuthentication(ClaimsPrincipal user)
    {
        var authState = Task.FromResult(new AuthenticationState(user));
        NotifyAuthenticationStateChanged(authState);
    }
}
