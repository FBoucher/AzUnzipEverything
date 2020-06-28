using System.IO;
using System.Threading.Tasks;

namespace AzUnzipEverything.Abstractions
{
    public interface IFileProcessor
    {
        Task ProcessFile(Stream blobStream);
    }
}
