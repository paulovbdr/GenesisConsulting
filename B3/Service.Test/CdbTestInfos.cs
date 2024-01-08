using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test
{
    public class CdbTestInfos
    {
        public InvestmentDtoCreate cdbDtoCreate;
        public InvestmentDtoCreate cdbDtoCreateInvalidAmount;
        public InvestmentDtoCreate cdbDtoCreateInvalidInvestmentTime;
        public InvestmentDtoCreateResult cdbDtoCreateResult;
        public CdbTestInfos()
        {
            cdbDtoCreate = new InvestmentDtoCreate() { Amount = 100, InvestmenTimeMonth = 2};
            cdbDtoCreateInvalidAmount = new InvestmentDtoCreate() { Amount = -100, InvestmenTimeMonth = 2 };
            cdbDtoCreateInvalidInvestmentTime = new InvestmentDtoCreate() { Amount = 100, InvestmenTimeMonth = 1 };
            cdbDtoCreateResult = new InvestmentDtoCreateResult() { GrossAmount = 101.95M, NetAmount = 101.51M };

        }
    }
}
