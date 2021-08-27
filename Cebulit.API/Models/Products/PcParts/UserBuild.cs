using System;
using System.Collections.Generic;
using Cebulit.API.Core.Models;
using Cebulit.API.Models.Auth;

namespace Cebulit.API.Models.Products.PcParts
{
    public class UserBuild : ProductSet
    {
        public DateTime GeneratedAt { get; set; }
        
        public int ProcessorId { get; set; }
        public Processor Processor { get; set; }

        public int MotherboardId { get; set; }
        public Motherboard Motherboard { get; set; }

        public int MemoryId { get; set; }
        public Memory Memory { get; set; }

        public int? GraphicsCardId { get; set; }
        public GraphicsCard GraphicsCard { get; set; }

        public ICollection<Storage> Storage { get; set; }

        public int PowerSupplyId { get; set; }
        public PowerSupply PowerSupply { get; set; }

        public int CaseId { get; set; }
        public Case Case { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}