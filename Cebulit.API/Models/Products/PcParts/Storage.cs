using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public enum StorageType
    {
        HDD, SSD
    }

    public enum StorageInterface
    {
        SATA, NVME
    }

    public class Storage : Product
    {
        public int Capacity { get; set; }
        public StorageType Type { get; set; }
        public int ReadSpeed { get; set; }
        public int WriteSpeed { get; set; }
        public StorageInterface Interface { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<StorageTagMatch> StorageTagMatches { get; set; }
        
        public class StorageTagMatch : TagMatch
        {
            public int StorageId { get; set; }
            public Storage Storage { get; set; }
        }
    }
}