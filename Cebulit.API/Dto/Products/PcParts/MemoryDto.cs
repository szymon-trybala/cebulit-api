using Cebulit.API.Dto.Core;

namespace Cebulit.API.Dto.Products.PcParts
{
    public class MemoryDto : ProductDto
    {
        public int Speed { get; set; }
        public int Latency { get; set; }
        public int Modules { get; set; }
        public int Capacity { get; set; }
    }
}