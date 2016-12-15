using System.Threading.Tasks;

namespace vok_web_api
{
    public interface IKeyVaultConfigurationReader
    {
        Task<string> GetSecretAsync(string settingName);
    }
}
