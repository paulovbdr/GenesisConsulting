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
        public InvestmentDtoCreateResult CalculateInvestment(InvestmentDtoCreate cdbDtoCreate)
        {
            CdbModel cdbModel = new CdbModel();

            if (cdbDtoCreate.Amount <= 0)
            {
                throw new Exception("Invalid amount!");
            }

            if (cdbDtoCreate.InvestmenTimeMonth <= 1)
            {
                throw new Exception("Invalid investment time!");
            }
            
            var result = cdbModel.CalculateInvestment(cdbDtoCreate.Amount, cdbDtoCreate.InvestmenTimeMonth);

            return result;
        }
    }
}
