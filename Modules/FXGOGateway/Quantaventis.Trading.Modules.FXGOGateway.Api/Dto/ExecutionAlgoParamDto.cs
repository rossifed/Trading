using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Dto
{
    public class ExecutionAlgoParamDto
    {
       public String Parameter { get; set; }

        public String Value { get; set; }
    }
}
