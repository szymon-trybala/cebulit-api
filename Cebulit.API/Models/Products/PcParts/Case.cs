using System.Collections.Generic;
using Cebulit.API.Core.Models;

namespace Cebulit.API.Models.Products.PcParts
{
    public class Case : Product
    {
        public MotherboardFormFactor FormFactor { get; set; }
        public ICollection<Build> Builds { get; set; }
        public ICollection<CaseTagMatch> CaseTagMatches { get; set; }
        
        public class CaseTagMatch : TagMatch
        {
            public int CaseId { get; set; }
            public Case Case { get; set; }
        }
    }
}