﻿using AzUnzipEverything.Abstractions;
using AzUnzipEverything.Infrastructure.Settings;
using Ionic.Zip;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AzUnzipEverything.Implementations
{
    public class FileProcessor : IFileProcessor
    {
        private readonly CloudBlobContainer _destinationContainer;
        private readonly SecretSettings _secretSettings;
        private readonly ILogger<FileProcessor> _logger;

        public FileProcessor(CloudBlobContainer destinationContainer, SecretSettings secretSettings, ILogger<FileProcessor> logger)
        {
            _destinationContainer = destinationContainer;
            _secretSettings = secretSettings;
            _logger = logger;
        }

        public async Task ProcessFile(Stream blobStream)
        {
            if (ZipFile.IsZipFile(blobStream, false))
            {
                _logger.LogInformation("Blob is a zip file; beginning extraction....");
                blobStream.Position = 0;
                var zipFile = ZipFile.Read(blobStream, new ReadOptions { Encoding = Encoding.UTF8 });

                foreach (var zipEntry in zipFile.Entries)
                {
                    if (zipEntry.UsesEncryption && zipEntry.Encryption != EncryptionAlgorithm.None)
                    {
                        zipFile.Password = _secretSettings.ZipPassword;
                    }

                    _logger.LogInformation($"Now processing {zipEntry.FileName}");

                    //Replace all NO digits, letters, or "-" by a "-" Azure storage is specific on valid characters
                    var validName = Regex.Replace(zipEntry.FileName, @"[^a-zA-Z0-9\-.]", "-").ToLower();

                    var blockBlob = _destinationContainer.GetBlockBlobReference(validName);
                    await using var fileStream = zipEntry.OpenReader();
                    await blockBlob.UploadFromStreamAsync(fileStream);

                    _logger.LogInformation($"{zipEntry.FileName} processed successfully and moved to destination container");
                }
            }
        }
    }
}