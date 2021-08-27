using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public class Build : ProductSet
    {
        public int ProcessorId { get; set; }
        public Processor Processor { get; set; }

        public int MotherboardId { get; set; }
        public Motherboard Motherboard { get; set; }

        public int MemoryId { get; set; }
        public Memory Memory { get; set; }

        public int? GraphicsCardId { get; set; }
        public GraphicsCard GraphicsCard { get; set; }

        public ICollection<Storage> Storage { get; set; }

        public int PowerSupplyId { get; set; }
        public PowerSupply PowerSupply { get; set; }

        public int CaseId { get; set; }
        public Case Case { get; set; }
        
        public ICollection<BuildTagMatch> BuildTagMatches { get; set; }
        
        public class BuildTagMatch : TagMatch
        {
            public int BuildId { get; set; }
            public Build Build { get; set; }
        }
    }
}