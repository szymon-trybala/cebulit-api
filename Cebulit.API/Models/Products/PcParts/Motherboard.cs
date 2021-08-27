using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public enum MotherboardFormFactor
    {
        ATX, microATX, miniITX
    }
    public class Motherboard : Product
    {
        public string Socket { get; set; }
        public int MemorySlots { get; set; }
        public MotherboardFormFactor FormFactor { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<MotherboardTagMatch> MotherboardTagMatches { get; set; }
        
        public class MotherboardTagMatch : TagMatch
        {
            public int MotherboardId { get; set; }
            public Motherboard Motherboard { get; set; }
        }
    }
}