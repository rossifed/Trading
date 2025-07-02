using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Options
{
    public class OrderMappingConfig
    {
        public List<FieldMapping> FieldMappings { get; set; }
        public Dictionary<string, Dictionary<string, string>> ValueMappings { get; set; }
        public List<FieldMapping> AllocationFieldMappings { get; set; }
       
    }

    public class FieldMapping {
        public string Source { get; set; }
        public string Destination { get; set; }
        public bool MapValue { get; set; }

    }
}
