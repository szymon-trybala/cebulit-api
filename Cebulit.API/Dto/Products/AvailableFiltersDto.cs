using System.Collections.Generic;

namespace Cebulit.API.Dto.Products
{
    public class AvailableFiltersDto
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public List<BrandGroup<NamedProduct>> Processors { get; set; }
        public List<int> RamCapacities { get; set; }
        public List<BrandGroup<NamedProduct>> GraphicsCards { get; set; }
        public List<int> StorageCapacities { get; set; }
        public List<BrandGroup<NamedProduct>> Cases { get; set; }

        public class BrandGroup<T>
        {
            public string Brand { get; set; }
            public List<T> Products { get; set; }
        }

        public class NamedProduct
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}