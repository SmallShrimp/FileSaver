using System;
using System.Collections.Generic;
using System.Text;

namespace X.FileSaver.Stores.Local
{
    public class LocalFileOptions
    {

        public string LocalFolder { get; set; } = "C:\\Users\\Default\\Downloads";

        public string GetFilePathFormat { get; set; } = "/api/kstfile/files/www/{0}";

        public LocalFileOptions()
        {

        }
    }
}
