using MedbaseLibrary.Helpers;
using MedbaseLibrary.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedbaseComponents.Shared;

public class CommonAuthStateProvider : AuthenticationStateProvider
{
    private IAuthMemory authMemory;
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
    public CommonAuthStateProvider(IAuthMemory auth)
    {
        authMemory = auth;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            string token = authMemory.IsSuccess().Result ? await authMemory.GetToken() : null;

            if (string.IsNullOrEmpty(token))
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(TokenToClaims(token), "JwtBearer"));
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    private IEnumerable<Claim> TokenToClaims(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtSecurityToken;

        jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var claims = jwtSecurityToken.Claims;

        return claims;
    }
    public async Task UpdateAuthenticationState(string token)
    {
        ClaimsPrincipal claimsPrincipal;

        if (token != null)
        {
            //User has logged in
            await authMemory.StoreToken(MedbaseLibrary.Helpers.Helpers.AuthMemoryName, token);
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(TokenToClaims(token), "JwtBearer"));
        }
        else
        {
            //User has logged out
            await authMemory.RemoveToken(MedbaseLibrary.Helpers.Helpers.AuthMemoryName);
            claimsPrincipal = _anonymous;
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}
