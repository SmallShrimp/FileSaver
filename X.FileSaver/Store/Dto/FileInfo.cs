using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace X.FileSaver.Store
{
    public class FileInfo
    {
        [Required]
        public byte[] Bytes { get; set; }

        [Required]
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary> 
        public long FileSize { get; set; }

        public string FileType { get; set; }

        public string UniqueFileName { get; set; }
    }
}
