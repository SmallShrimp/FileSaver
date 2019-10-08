using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Volo.Abp.Threading;
using X.FileSaver.Store;
using X.FileSaver.Store.Dto;
using X.FileSaver.Stores.MongoGridFS.Extensions;

namespace X.FileSaver.Stores.MongoGridFS
{
    public class MongoGridStore : IFileStore
    {
        public string StoreName => MongoGridStore.GetName();
        private readonly IStorageService _storageService;
        public MongoGridStore(
            IStorageService storageService)
        {
            _storageService = storageService;
        }

        public static string GetName()
        {
            return typeof(MongoGridStore).Name;
        }

        public RawFileInfo Get(string fileName)
        {
            var downloadResult = AsyncHelper.RunSync(() => _storageService.DownloadFileAsync(fileName));

            using (BinaryReader reader = new BinaryReader(downloadResult.Item1))
            {
                var bytes = reader.ReadBytes((int)downloadResult.Item1.Length);
                return new RawFileInfo
                {
                    Bytes = bytes,
                    FileType = downloadResult.Item2.ContentType,
                    FileName = downloadResult.Item2.Name
                };
            }
        }

        public FileStoreHandResult Save(Store.FileInfo file)
        {

            var filedetail = AsyncHelper.RunSync(() => _storageService.UploadFileFromBytesAsync(file.Bytes, new FileDetails
            {
                Name = file.FileName,
                Size = file.FileSize,
                AddedDate = DateTime.Now,
                AddedBy = "",
                Description = file.FileName,
                Tags = new List<string>(),
                LastModified = DateTime.Now,
                ContentType = file.FileType
            }));
            return new FileStoreHandResult
            {
                StoreName = this.StoreName,
                FileName = filedetail.Id,
                FileSize = file.FileSize,
                FileType = file.FileType,
                FileAddress = "",
                AddressType = AddressType.网络路径,
                Raw = new RawFileInfo { Bytes = file.Bytes, FileType = file.FileType }
            };

        }
    }
}
