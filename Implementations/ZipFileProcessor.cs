using AzUnzipEverything.Abstractions;
using AzUnzipEverything.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzUnzipEverything.Implementations
{
    public class ZipFileProcessor : FileProcessorBase
    {
        private readonly SecretSettings _secretSettings;
        private readonly ILogger<FileProcessorBase> _logger;

        public ZipFileProcessor(CloudBlobContainer destinationContainer, SecretSettings secretSettings, ILogger<FileProcessorBase> logger) : base(destinationContainer, logger)
        {
            _secretSettings = secretSettings;
            _logger = logger;
        }

        public override async Task ProcessFile(Stream blobStream)
        {
            if (ZipArchive.IsZipFile(blobStream, _secretSettings?.ZipPassword))
            {
                var zipReaderOptions = new ReaderOptions()
                {
                    ArchiveEncoding = new ArchiveEncoding(Encoding.UTF8, Encoding.UTF8), LookForHeader = true,
                    Password = _secretSettings?.ZipPassword
                };

                _logger.LogInformation("Blob is a zip file; beginning extraction....");
                blobStream.Position = 0;

                using var reader = ZipArchive.Open(blobStream, zipReaderOptions);
                
                await ExtractArchiveFiles(reader.Entries);
            }
        }
    }
}