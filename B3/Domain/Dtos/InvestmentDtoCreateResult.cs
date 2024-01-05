using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class InvestmentDtoCreateResult
    {
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
    }
}
