using System;
using System.Collections.Generic;
using System.Text;

namespace X.FileSaver.Store.Dto
{
    public class FileSavedResult
    {
        public List<FileStoreHandResult> Items { get; }
        public FileSavedResult()
        {
            Items = new List<FileStoreHandResult>();
        }
    }
}
