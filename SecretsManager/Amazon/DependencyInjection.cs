using Amazon.Interfaces;
using Amazon.SecretsManager;
using Amazon.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAmazon(this IServiceCollection services)
        {
            services.AddSingleton<IAmazonSecretsManager>(sp => new AmazonSecretsManagerClient(RegionEndpoint.EUWest2));
            services.AddSingleton<ISecretManagerService, SecretManagerService>();

            return services;
        }
    }
}
