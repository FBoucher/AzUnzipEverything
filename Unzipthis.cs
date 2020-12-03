using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzUnzipEverything
{
    public static class Unzipthis
    {
        [FunctionName("Unzipthis")]
        public static async Task Run(
            [BlobTrigger("input-files/{name}", Connection = "cloud5mins_storage")]CloudBlockBlob blob,
            string name, 
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob Name:{name}");
            
            // Exit if not a zip file
            if(name.Split('.').Last().ToLower() != "zip")
            {
                log.LogError($"{name} is not a zip file");
                return;           
            }

            var destinationStorage = Environment.GetEnvironmentVariable("destinationStorage");
            var destinationContainer = Environment.GetEnvironmentVariable("destinationContainer");
         
            try
            {  
                var storageAccount = CloudStorageAccount.Parse(destinationStorage);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(destinationContainer);

                using(var sourceStream = await blob.OpenReadAsync())
                {
                    using(var zipArchive = new ZipArchive(sourceStream))
                    {
                        foreach(var zipArchiveEntry in zipArchive.Entries)
                        {                            
                            //Replace all NO digits, letters, or "-" by a "-" Azure storage is specific on valid characters
                            var targetFileName = Regex.Replace(zipArchiveEntry.Name, @"[^a-zA-Z0-9\-.]","-").ToLower();                            
                            var targetBlob = container.GetBlockBlobReference(targetFileName);
                            using(var sourceFileStream = zipArchiveEntry.Open())
                            {
                                log.LogInformation($"started extracting {zipArchiveEntry.Name} to {targetFileName}");
                                await targetBlob.UploadFromStreamAsync(sourceFileStream);
                                log.LogInformation($"completed extracting {zipArchiveEntry.Name} to {targetFileName}");
                            }
                        }
                    }
                }
            }
            catch(Exception ex){                
                log.LogError(ex, ex.Message);
            }            
        }
    }
}