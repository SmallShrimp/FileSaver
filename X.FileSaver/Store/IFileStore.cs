using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using X.FileSaver.Store.Dto;

namespace X.FileSaver.Store
{
    public interface IFileStore : ITransientDependency
    {


        string StoreName { get; }

        FileStoreHandResult Save(FileInfo file);
        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="fileName">文件名称 包含扩展名</param>
        /// <returns></returns>
        RawFileInfo Get(string fileName);

    }
}
