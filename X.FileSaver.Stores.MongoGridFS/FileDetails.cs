using System;
using System.Collections.Generic;
using System.Text;

namespace X.FileSaver.Stores.MongoGridFS
{
    public class FileDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public DateTime LastModified { get; set; }
        public string ContentType { get; set; }
    }
}
