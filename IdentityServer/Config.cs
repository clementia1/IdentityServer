using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("website.com")
                {
                    Scopes = new List<Scope>
                    {
                        new Scope("website.com")
                    },
                },
                new ApiResource("webapi")
                {
                    Scopes = new List<Scope>
                    {
                        new Scope("webapi.webapi")
                    },
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "pkce_client",
                    ClientName = "Pizza Shop",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RedirectUris = { "http://168.62.49.228/" },
                    PostLogoutRedirectUris = { "http://168.62.49.228/" },
                    AllowedScopes = { "openid", "profile", "website.com" },
                    RequirePkce = true,
                    RequireConsent = false,
                    AllowPlainTextPkce = false
                },
                new Client
                {
                    ClientId = "webapi_client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("not-a-secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "webapi.webapi" }
                }
            };
        }
    }
}