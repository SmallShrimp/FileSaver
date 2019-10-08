using System;
using System.Collections.Generic;
using System.Text;

namespace X.FileSaver.Store.Dto
{
    public class FileStoreHandResult
    {

        public string StoreName { get; set; }

        public string FileName { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary> 
        public long FileSize { get; set; }

        public string FileType { get; set; }

        public string FileAddress { get; set; }

        public AddressType AddressType { get; set; }

        public RawFileInfo Raw { get; set; }
    }

    public enum AddressType
    {
        网络路径 = 0,
        本地绝对路径,
        本地相对路径

    }
}
