using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using X.FileSaver.Store.Dto;

namespace X.FileSaver.Store
{
    public interface IFileStoreManager : ISingletonDependency
    {

        /// <summary>
        /// 保存文件 返回文件访问地址
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        FileSavedResult SaveFile(FileInfo file);

        /// <summary>
        /// 获取文件 根据文件名称
        /// </summary>
        /// <param name="fileName">文件标识 根据不同的store区别传入</param>
        /// <param name="storeName">存储文件的store名称</param>
        /// <returns></returns>
        RawFileInfo GetFile(string fileName, string storeName);

    }
}
