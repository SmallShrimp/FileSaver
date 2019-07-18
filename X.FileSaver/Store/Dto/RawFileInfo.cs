using System;
using System.Collections.Generic;
using System.Text;

namespace X.FileSaver.Store
{
    public class RawFileInfo
    {
        public byte[] Bytes { get; set; } = null;

        public string FileType { get; set; }
    }
}
