using System.Collections.Generic;

namespace Cebulit.API.Params
{
    public class BuildsFiltersParams
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public List<int> ProcessorIds { get; set; }
        public List<int> RamCapacities { get; set; }
        public List<int> GraphicsCardIds { get; set; }
        public List<int> StorageCapacities { get; set; }
        public List<int> CaseIds { get; set; }
        public string OrderBy { get; set; }
    }
}