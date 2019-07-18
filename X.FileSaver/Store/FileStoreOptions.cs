using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Collections;

namespace X.FileSaver.Store
{
    public class FileStoreOptions
    {
        public ITypeList<IFileStore> FileStores { get; }

        public FileStoreOptions()
        {
            FileStores = new TypeList<IFileStore>();
        }

        public void AddStore<T>() where T : IFileStore
        {

            FileStores.AddFirst(typeof(T));
        }

    }
}
