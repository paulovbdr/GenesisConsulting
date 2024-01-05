using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class InvestmentDtoCreate
    {
        [Required(ErrorMessage = "Amount is required!")]
        [Range(0.1, (Double) decimal.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Investment time is required!")]
        [Range(2, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int InvestmenTimeMonth { get; set; }
    }
}
