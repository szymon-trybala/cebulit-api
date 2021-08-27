using Cebulit.API.Dto.Core;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Dto.Products.PcParts
{
    public class CaseDto : ProductDto
    {
        public MotherboardFormFactor FormFactor { get; set; }
    }
}