using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public class Memory : Product
    {
        public int Speed { get; set; }
        public int Latency { get; set; }
        public int Modules { get; set; }
        public int Capacity { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<MemoryTagMatch> MemoryTagMatches { get; set; }
        
        public class MemoryTagMatch : TagMatch
        {
            public int MemoryId { get; set; }
            public Memory Memory { get; set; }
        }
    }
}