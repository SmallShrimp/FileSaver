using MimeTypeMap.List;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Volo.Abp;
using Volo.Abp.IO;
using X.FileSaver.Store;
using X.FileSaver.Store.Dto;
using System.Linq;

namespace X.FileSaver.Stores.Local
{
    public class LocalFileStore : IFileStore
    {
        LocalFileOptions Options { get; }
        public LocalFileStore(IOptions<LocalFileOptions> options)
        {
            Options = options.Value;
        }

        public string StoreName { get; set; } = typeof(LocalFileStore).Name;


        public RawFileInfo Get(string fileName)
        {

            Check.NotNullOrWhiteSpace(fileName, nameof(fileName));

            var localFolder = GetFilePath();
            string filePath = Path.Combine(localFolder, fileName);
            if (File.Exists(filePath))
            {

                var bytes = File.ReadAllBytes(filePath);
                var fileExtension = Path.GetExtension(filePath);
                return new RawFileInfo
                {
                    Bytes = bytes,
                    FileType = MimeTypeMap.List.MimeTypeMap.GetMimeType(fileExtension).FirstOrDefault() ?? "text/plain"
                };
            }

            return new RawFileInfo
            {
                Bytes = new byte[] { },
                FileType = "text/plain"
            };
        }

        public FileStoreHandResult Save(Store.FileInfo file)
        {

            if (Options.LocalFolder.IsNullOrWhiteSpace())
            {
                throw new Exception("本地存储位置不能为空");
            }

            var uniqueFileName = GenerateUniqueFileName(Path.GetExtension(file.FileName));
            file.UniqueFileName = uniqueFileName;
            var localFolder = GetFilePath();
            // 创建文件夹
            DirectoryHelper.CreateIfNotExists(localFolder);

            var filePath = Path.Combine(localFolder, uniqueFileName);
            // 保存文件
            File.WriteAllBytes(filePath, file.Bytes);

            return new FileStoreHandResult
            {
                StoreName = StoreName,
                FileName = uniqueFileName,
                FileAddress = filePath,
                AddressType = AddressType.本地绝对路径,
                Raw = new RawFileInfo { Bytes = file.Bytes, FileType = file.FileType },
                FileType = file.FileType,
                FileSize = file.FileSize
            };
        }

        private string GetFilePath()
        {
            return string.Format(Options.LocalFolder, DateTime.Now.ToString("yyyyMMdd"));
        }

        protected virtual string GenerateUniqueFileName(string extension, string prefix = null, string postfix = null)
        {
            return prefix + Guid.NewGuid().ToString("N") + postfix + extension;
        }
    }
}
