using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public class PowerSupply : Product
    {
        public int Power { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<PowerSupplyTagMatch> PowerSupplyTagMatches { get; set; }
        
        public class PowerSupplyTagMatch : TagMatch
        {
            public int PowerSupplyId { get; set; }
            public PowerSupply PowerSupply { get; set; }
        }
    }
}