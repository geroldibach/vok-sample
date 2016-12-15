using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace vok_web_api
{
    /// <summary>
    /// </summary>
    public class KeyVaultConfigurationReader : IKeyVaultConfigurationReader
    {
        private readonly string _appClientId;
        private readonly string _appClientSecret;
        private readonly string _vault;

        public KeyVaultConfigurationReader(string appClientId, string vaultName, string appClientSecret)
        {
            _appClientId = appClientId;
            _appClientSecret = appClientSecret;
            _vault = $"https://{vaultName}.vault.azure.net:443/";
        }

        public async Task<string> GetSecretAsync(string settingName)
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(this.GetTokenAsync));
            var secret = await kv.GetSecretAsync(this._vault, settingName);
            return secret?.Value;
        }

        private async Task<string> GetTokenAsync(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            var clientCred = new ClientCredential(this._appClientId, this._appClientSecret);
            var result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            return result.AccessToken;
        }
    }
}