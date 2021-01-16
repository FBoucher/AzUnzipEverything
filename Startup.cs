using AzUnzipEverything;
using AzUnzipEverything.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
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

            builder.Services.AddAzureKeyVaultConfiguration(configurationBuilder);
            
            builder.Services.AddBlobStorage();

            builder.Services.AddSupportedArchiveTypes();
        }
    }
}
