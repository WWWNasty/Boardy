// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = JwtClaimTypes.Role,
                    DisplayName = JwtClaimTypes.Role,
                    UserClaims = { JwtClaimTypes.Role }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new[]
            {
                new ApiResource("Api", "Boardy Api", new List<string>
                {
                    JwtClaimTypes.Name,
                    JwtClaimTypes.Role
                })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "UI",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    //RequireConsent = false,
                    //TODO get secret key from configuration
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    RedirectUris = { "https://localhost:44372/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44372/signout-callback-oidc" },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        JwtClaimTypes.Role,
                        "Api"

                    }
                }
            };
        }
    }
}