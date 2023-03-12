using IdentityModel;
using IdentityServer4.Models;

namespace Sheduler.Identity;

public class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>()
            {
              new ApiScope("ShedulerWebApi", "Web Api")  
            };
    
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("ShedulerWebApi", "Web Api", new[] { JwtClaimTypes.Name })
            {
                Scopes = { "ShedulerWebApi" }
            }
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client()
            {
                ClientId = "sheduler-web-api",
                ClientName = "Sheduler Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "http://.../signin-oidc"
                },
                AllowedCorsOrigins =
                {
                    "http://..."
                },
                PostLogoutRedirectUris =
                {
                    "http://.../signout-oidc"
                },
                AllowedScopes =
                {
                    IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                    "ShedulerWebApi"
                },
                AllowAccessTokensViaBrowser = true
            }
        };
}