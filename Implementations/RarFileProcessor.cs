using AzUnzipEverything.Abstractions;
using AzUnzipEverything.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Readers;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzUnzipEverything.Implementations
{
    public class RarFileProcessor : FileProcessorBase
    {
        private readonly SecretSettings _secretSettings;
        private readonly ILogger<FileProcessorBase> _logger;

        public RarFileProcessor(CloudBlobContainer destinationContainer, SecretSettings secretSettings, ILogger<FileProcessorBase> logger) : base(destinationContainer, logger)
        {
            _secretSettings = secretSettings;
            _logger = logger;
        }

        public override async Task ProcessFile(Stream blobStream)
        {
            var rarReaderOptions = new ReaderOptions()
            {
                ArchiveEncoding = new ArchiveEncoding(Encoding.UTF8, Encoding.UTF8),
                Password = _secretSettings?.ZipPassword,
                LookForHeader = true
            };

            if (RarArchive.IsRarFile(blobStream, rarReaderOptions))
            {
                _logger.LogInformation("Blob is a rar file; beginning extraction....");
                blobStream.Position = 0;

                using var reader = RarArchive.Open(blobStream, rarReaderOptions);

                await ExtractArchiveFiles(reader.Entries);
            }
        }
    }
}