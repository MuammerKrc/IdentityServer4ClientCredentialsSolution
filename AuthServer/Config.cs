using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api1"){Scopes ={"api1.read","api1.update","api1.write"}},
                new ApiResource("resource_api2"){Scopes = {"api2.read","api2.update","api2.write"}}
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","read for api1"),
                new ApiScope("api1.write","write for api1"),
                new ApiScope("api1.update","update for api1"),
                new ApiScope("api2.read","read for api2"),
                new ApiScope("api2.write","write for api2"),
                new ApiScope("api2.update","update for api2"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "Client1",
                    ClientName = "Client1 app",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1.read", "api2.write","api2.update"},
                },                new Client()
                {
                    ClientId = "Client2",
                    ClientName = "Client2 app",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1.write", "api2.read","api1.update"},
                }
            };
        }

    }
}
