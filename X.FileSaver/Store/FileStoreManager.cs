using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.FileSaver.Store.Dto;

namespace X.FileSaver.Store
{
    public class FileStoreManager : IFileStoreManager
    {
        private readonly Lazy<List<IFileStore>> _fileStores;
        protected IReadOnlyList<IFileStore> FileStores => _fileStores.Value
            .Where(s => !Blacklist.Contains(s.StoreName))
            .ToList();
        private IList<string> Blacklist { get; set; }

        public FileStoreManager(
            IOptions<FileStoreOptions> options,
            IServiceProvider serviceProvider)
        {

            Blacklist = options.Value.Blacklist;

            _fileStores = new Lazy<List<IFileStore>>(
                () => options.Value.FileStores
                .Select(s => serviceProvider.GetRequiredService(s) as IFileStore)
                .ToList(),
                true
                );
        }

        /// <summary>
        /// 文件处理
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public FileSavedResult SaveFileAndGetResult([NotNull] FileInfo file)
        {
            var result = new FileSavedResult();

            SetFileName(file);
            foreach (var store in FileStores)
            {
                // store.StoreName
                FileStoreHandResult storeResult = store.Save(file);
                storeResult.Raw = null;
                result.Items.Add(storeResult);
            }
            return result;
        }

        private void SetFileName(FileInfo file)
        {
            if (file.UniqueFileName.IsNullOrWhiteSpace())
            {
                var uniqueFileName = GenerateUniqueFileName(Path.GetExtension(file.FileName));
                file.UniqueFileName = uniqueFileName;
            }
        }

        public RawFileInfo GetFile(string fileName, string storeName)
        {
            return FileStores
                .FirstOrDefault(s => s.StoreName == storeName)?.Get(fileName);
        }

        protected virtual string GenerateUniqueFileName(string extension, string prefix = null, string postfix = null)
        {
            return prefix + Guid.NewGuid().ToString("N") + postfix + extension;
        }

        /// <summary>
        /// 异步处理文件
        /// </summary>
        /// <param name="file"></param>
        public string SaveFile(FileInfo file)
        {
            SetFileName(file);
            foreach (var store in FileStores)
            {
                new TaskFactory().StartNew(() => store.Save(file));
            }
            return file.UniqueFileName;
        }
    }
}
