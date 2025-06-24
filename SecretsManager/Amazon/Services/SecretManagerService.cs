using Amazon.Interfaces;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.Extensions.Options;

namespace Amazon.Services
{
    public class SecretManagerService(IAmazonSecretsManager secretsManager, IOptions<AwsResources> awsResources) : ISecretManagerService
    {
        private readonly IAmazonSecretsManager _secretsManager = secretsManager;
        private readonly AwsResources _awsResources = awsResources.Value;

        public async Task<string> GetSecretAsync(string secretKey)
        {
            var response = await _secretsManager.GetSecretValueAsync(new GetSecretValueRequest
            {
                SecretId = GetSecretName(secretKey)
            });

            return response.SecretString;
        }

        private string GetSecretName(string secretKey)
        {
            if (string.IsNullOrEmpty(_awsResources.StageAlias))
                return secretKey;

            return $"{secretKey}-{_awsResources.StageAlias}";
        }
    }
}
