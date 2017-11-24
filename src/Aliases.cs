namespace Cake.Deploy.Azure.Authentication
{
    using Core;
    using Core.Annotations;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;
    using System;

    [CakeAliasCategory("Deploy.Azure")]
    [CakeNamespaceImport("Microsoft.Rest")]
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

        /// <summary>
        /// Login to Azure Resource Manager as active directory application
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="tenantId">TenantId</param>
        /// <param name="clientId">Other names: servicePrincipalId in VSTS, Application ID in Azure Portal</param>
        /// <param name="secret">Other names: servicePrincipalKey in VSTS, Password in Azure Portal</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static ServiceClientCredentials LoginAzure(this ICakeContext ctx, string tenantId, string clientId, string secret)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
            {
                throw new ArgumentNullException(nameof(tenantId));
            }

            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }

            return ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, secret).GetAwaiter().GetResult();
        }
    }
}
