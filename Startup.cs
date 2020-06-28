using AzUnzipEverything;
using AzUnzipEverything.Abstractions;
using AzUnzipEverything.Implementations;
using AzUnzipEverything.Infrastructure.Settings;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AzUnzipEverything
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            var config = configurationBuilder.Build();

            config = configurationBuilder.AddAzureKeyVault(config["KeyVaultUri"])
                .Build();
            builder.Services.AddSingleton<IConfiguration>(config);

            builder.Services.AddSingleton(provider =>
            {
                var storageAccount = CloudStorageAccount.Parse(config["destinationStorage"]);
                var blobClient = storageAccount.CreateCloudBlobClient();
                return blobClient.GetContainerReference(config["destinationContainer"]);
            });

            builder.Services.AddSingleton(provider => new SecretSettings
            {
                KeyVaultUri = config["KeyVaultUri"],
                ZipPassword = config["ZipPassword"]
            });

            builder.Services.AddSingleton<IFileProcessor, FileProcessor>();
        }
    }
}
