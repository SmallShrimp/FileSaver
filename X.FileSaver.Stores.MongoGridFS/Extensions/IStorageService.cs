using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace X.FileSaver.Stores.MongoGridFS.Extensions
{
    public interface IStorageService : ITransientDependency
    {
        Task<FileDetails> UploadFileAsync(Stream fileStream, FileDetails fileDetails);

        Task<FileDetails> UploadFileFromBytesAsync(byte[] bytes, FileDetails fileDetails);

        Task<(Stream, FileDetails)> DownloadFileAsync(string id);
        Task<FileDetails> UpdateFileDetailsAsync(FileDetails details);
        Task<FileDetails> GetFileDetailsAsync(string id);
        Task<IEnumerable<FileDetails>> GetAllFileDetailsAsync();
        Task<IEnumerable<FileDetails>> GetFileDetailsByTagAsync(string tag);
        Task<string> DeleteFileAsync(string id);
    }
}
