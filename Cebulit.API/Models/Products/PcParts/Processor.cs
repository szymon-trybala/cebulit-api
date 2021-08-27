using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public class Processor : Product
    {
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double BoostClock { get; set; }
        public string Socket { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<ProcessorTagMatch> ProcessorTagMatches { get; set; }
        
        public class ProcessorTagMatch : TagMatch
        {
            public int ProcessorId { get; set; }
            public Processor Processor { get; set; }
        }
    }
}