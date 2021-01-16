using AzUnzipEverything.Abstractions;
using AzUnzipEverything.Implementations;
using AzUnzipEverything.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;

namespace AzUnzipEverything.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSupportedArchiveTypes(this IServiceCollection services)
        {
            services.AddSingleton<IFileProcessor, ZipFileProcessor>();
            services.AddSingleton<IFileProcessor, RarFileProcessor>();

            services.AddSingleton(provider => new Dictionary<string, IFileProcessor>()
            {
                {
                    Constants.SupportedExtensions.Zip,
                    new ZipFileProcessor(provider.GetService<CloudBlobContainer>(),
                        provider.GetService<SecretSettings>(), provider.GetService<ILogger<ZipFileProcessor>>())
                },
                {
                    Constants.SupportedExtensions.Rar,
                    new RarFileProcessor(provider.GetService<CloudBlobContainer>(),
                        provider.GetService<SecretSettings>(), provider.GetService<ILogger<RarFileProcessor>>())
                }
            });
        }

        public static void AddAzureKeyVaultConfiguration(this IServiceCollection services, IConfigurationBuilder configurationBuilder)
        {
            var config = configurationBuilder.Build();
            config = configurationBuilder.AddAzureKeyVault(config["KeyVaultUri"]).Build();

            services.AddSingleton<IConfiguration>(config);

            services.AddSingleton(provider => new SecretSettings
            {
                KeyVaultUri = config["KeyVaultUri"],
                ZipPassword = config["ZipPassword"]
            });
        }

        public static void AddBlobStorage(this IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var config = provider.GetService<IConfiguration>();

                var storageAccount = CloudStorageAccount.Parse(config["destinationStorage"]);
                var blobClient = storageAccount.CreateCloudBlobClient();
                return blobClient.GetContainerReference(config["destinationContainer"]);
            });
        }
    }
}