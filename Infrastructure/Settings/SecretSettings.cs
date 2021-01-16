using System.Diagnostics.CodeAnalysis;

namespace AzUnzipEverything.Infrastructure.Settings
{
    [ExcludeFromCodeCoverage]
    public class SecretSettings
    {
        public string KeyVaultUri { get; set; }
        public string ZipPassword { get; set; }
    }
}
