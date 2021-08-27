using Cebulit.API.Dto.Core;

namespace Cebulit.API.Dto.Products.PcParts
{
    public class ProcessorDto : ProductDto
    {
        public int Cores { get; set; }
        public int Threads { get; set; }
        public double BaseClock { get; set; }
        public double BoostClock { get; set; }
        public string Socket { get; set; }
    }
}