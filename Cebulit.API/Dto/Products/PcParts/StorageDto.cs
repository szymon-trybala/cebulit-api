using Cebulit.API.Dto.Core;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Dto.Products.PcParts
{
    public class StorageDto : ProductDto
    {
        public int Capacity { get; set; }
        public int ReadSpeed { get; set; }
        public int WriteSpeed { get; set; }
        public StorageType Type { get; set; }
        public StorageInterface Interface { get; set; }
    }
}