using Domain.Dtos;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CdbService : IInvestimentService
    {
        public InvestmentDtoCreateResult CalculateInvestment(InvestmentDtoCreate investmentDtoCreate)
        {
            CdbModel cdbModel = new();

            if (investmentDtoCreate.Amount <= 0)
            {
                throw new ArgumentException("Invalid amount!");
            }

            if (investmentDtoCreate.InvestmenTimeMonth <= 1)
            {
                throw new ArgumentException("Invalid investment time!");
            }
            
            var result = cdbModel.CalculateInvestment(investmentDtoCreate.Amount, investmentDtoCreate.InvestmenTimeMonth);

            return result;
        }
    }
}
