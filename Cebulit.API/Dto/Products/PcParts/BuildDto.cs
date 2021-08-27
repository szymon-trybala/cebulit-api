using System.Collections.Generic;
using Cebulit.API.Dto.Core;

namespace Cebulit.API.Dto.Products.PcParts
{
    public class BuildDto : ProductSetDto
    {
        public ProcessorDto Processor { get; set; }
        public MotherboardDto Motherboard { get; set; }
        public MemoryDto Memory { get; set; }
        public GraphicsCardDto GraphicsCard { get; set; }
        public List<StorageDto> Storage { get; set; }
        public PowerSupplyDto PowerSupply { get; set; }
        public CaseDto Case { get; set; }
        public bool IsGeneratedForUser { get; set; }
    }
}