using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public class GraphicsCard : Product
    {
        public int MemoryCapacity { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<GraphicsCardTagMatch> GraphicsCardsTagMatches { get; set; }
        
        public class GraphicsCardTagMatch : TagMatch
        {
            public int GraphicsCardId { get; set; }
            public GraphicsCard GraphicsCard { get; set; }
        }
    }
}