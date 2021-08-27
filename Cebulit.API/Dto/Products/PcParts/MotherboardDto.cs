using Cebulit.API.Dto.Core;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Dto.Products.PcParts
{
    public class MotherboardDto : ProductDto
    {
        public string Socket { get; set; }
        public int MemorySlots { get; set; }
        public MotherboardFormFactor FormFactor { get; set; }
    }
}