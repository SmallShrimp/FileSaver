using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Collections;
using X.FileSaver.Store.Dto;

namespace X.FileSaver.Store
{
    public class FileStoreOptions
    {
        public ITypeList<IFileStore> FileStores { get; }


        /// <summary>
        ///  黑名单store name
        ///  在此列表中的store名称对应的store不会被使用
        /// </summary>
        public IList<string> Blacklist { get; set; }

        public FileStoreOptions()
        {
            FileStores = new TypeList<IFileStore>();
            Blacklist = new List<string>();
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
