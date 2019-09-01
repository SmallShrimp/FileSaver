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

        public void AddTop<T>() where T : IFileStore
        {
            FileStores.AddFirst(typeof(T));
        }

        public void AddLast<T>() where T : IFileStore
        {
            FileStores.AddLast(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource">新的类型</typeparam>
        /// <typeparam name="TReplaced">被替换的类型</typeparam>
        public void Replace<TSource, TReplaced>()
            where TSource : IFileStore
            where TReplaced : IFileStore
        {
            if (!FileStores.Contains(typeof(TReplaced)))
            {
                FileStores.Add(typeof(TSource));
            }
            else
            {
                FileStores.ReplaceOne(typeof(TReplaced), typeof(TSource));
            }

        }
    }
}
