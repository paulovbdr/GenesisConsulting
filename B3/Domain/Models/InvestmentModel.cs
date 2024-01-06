using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class InvestmentModel
    {
        protected InvestmentModel()
        {

        }

        public abstract InvestmentDtoCreateResult CalculateInvestment(decimal amount, int investmentTimeMonth);
        public abstract decimal CalculateTax(decimal initialAmount, decimal grossAmount, int investmentTimeMonth);
    }
}
