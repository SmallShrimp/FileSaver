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

        RawFileInfo Get(string fileName);

    }
}
