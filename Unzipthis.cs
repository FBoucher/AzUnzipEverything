using AzUnzipEverything.Abstractions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzUnzipEverything
{
    public class Unzipthis
    {
        private readonly Dictionary<string, IFileProcessor> _fileProcessorMap;
        private readonly ILogger<Unzipthis> _logger;

        public Unzipthis(Dictionary<string, IFileProcessor> fileProcessorMap, ILogger<Unzipthis> logger)
        {
            _fileProcessorMap = fileProcessorMap;
            _logger = logger;
        }

        [FunctionName("Unzipthis")]
        public async Task Run([BlobTrigger("input-files/{name}", Connection = "cloud5mins_storage")] Stream myBlob, string name)
        {
            _logger.LogInformation($"C# Blob trigger function Processing blob\n Name:{name}");

            try
            {
                await _fileProcessorMap[Path.GetExtension(name)].ProcessFile(myBlob);
                _logger.LogInformation("C# Blob trigger function Processed blob\n Name:{name}");
            }
            catch (ArgumentException aex)
            {
                _logger.LogInformation("Something went wrong while processing {blobName}, Error: {exception}", name,
                    aex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong while processing {blobName}, Error: {exception}", name,
                    ex.Message);
            }
        }
    }
}