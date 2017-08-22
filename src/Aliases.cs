namespace Cake.Deploy.Azure.Authentication
{
    using Cake.Core;
    using Cake.Core.Annotations;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;
    using System;

    [CakeAliasCategory("Sample")]
    public static class AddinAliases
    {
        private const string WELLKNOWN_CLIENTID = "1950a258-227b-4e31-a9cf-717495945fc2";

        [CakeMethodAlias]
        public static ServiceClientCredentials LoginAzureRM(this ICakeContext ctx, string tenantId, string loginName, string password)
        {
            if(string.IsNullOrWhiteSpace(tenantId))
            {
                throw new ArgumentNullException(nameof(tenantId));
            }

            if(string.IsNullOrWhiteSpace(loginName))
            {
                throw new ArgumentNullException(nameof(loginName));
            }

            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            return UserTokenProvider.LoginSilentAsync(WELLKNOWN_CLIENTID, tenantId, loginName, password).GetAwaiter().GetResult();
        }
    }
}
