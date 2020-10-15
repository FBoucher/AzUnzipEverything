using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SharpCompress.Archives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzUnzipEverything.Abstractions
{
    public abstract class FileProcessorBase : IFileProcessor
    {
        private readonly CloudBlobContainer _destinationContainer;
        private readonly ILogger<FileProcessorBase> _logger;

        protected FileProcessorBase(CloudBlobContainer destinationContainer, ILogger<FileProcessorBase> logger)
        {
            _destinationContainer = destinationContainer;
            _logger = logger;
        }

        public abstract Task ProcessFile(Stream blobStream);

        protected async Task ExtractArchiveFiles(IEnumerable<IArchiveEntry> archiveEntries)
        {
            foreach (var archiveEntry in archiveEntries.Where(entry => !entry.IsDirectory))
            {
                _logger.LogInformation($"Now processing {archiveEntry.Key}");

                NameValidator.ValidateBlobName(archiveEntry.Key);

                var blockBlob = _destinationContainer.GetBlockBlobReference(archiveEntry.Key);
                await using var fileStream = archiveEntry.OpenEntryStream();
                await blockBlob.UploadFromStreamAsync(fileStream);

                _logger.LogInformation(
                    $"{archiveEntry.Key} processed successfully and moved to destination container");
            }
        }
    }
}