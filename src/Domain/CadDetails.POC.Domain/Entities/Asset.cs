using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDetails.POC.Domain.Entities
{
    public class Asset
    {
        public string? Name { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int PopularityScore { get; set; }

        public bool IsValid() => !string.IsNullOrWhiteSpace(Name);
    }
}
