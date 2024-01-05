using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CdbModel : InvestmentModel
    {
        private static decimal _taxUntilSixMonth = 22.5M;
        private static decimal _taxUntilTwelveMonth = 20M;
        private static decimal _taxUntilTwentyFourMonth = 17.5M;
        private static decimal _taxAboveTwentyFourMonth = 15M;
        protected static decimal _cdi = 0.9M;
        protected static decimal _tb = 108M;
        public CdbModel()
        {
        }

        public override InvestmentDtoCreateResult CalculateInvestment(decimal amount, int investmentTimeMonth)
        {
            InvestmentDtoCreateResult investmentDtoCreateResult = new InvestmentDtoCreateResult();
            decimal grossAmount = amount;
            var cdiTbValue = GetCdiTbValue();

            for (int month = 1; month <= investmentTimeMonth; month++)
            {
                grossAmount = grossAmount * cdiTbValue; 
            }
            
            investmentDtoCreateResult.GrossAmount = Math.Round(grossAmount, 2);
            investmentDtoCreateResult.NetAmount = Math.Round(grossAmount - CalculateTax(amount, grossAmount, investmentTimeMonth), 2);

            return investmentDtoCreateResult;

        }

        public override decimal CalculateTax(decimal initialAmount, decimal grossAmount, int investmentTimeMonth)
        {
            var investimentAmount = grossAmount - initialAmount;
            var tax = GetTax(investmentTimeMonth);

            return investimentAmount * tax / 100;
        }

        private decimal GetCdiTbValue()
        {
            return 1 + (_cdi / 100) * (_tb / 100);
        }

        private decimal GetTax(int investmentTime)
        {
            switch (investmentTime)
            {
                case >= 2 and <= 6:
                    return _taxUntilSixMonth;
                case >= 7 and <= 12:
                    return _taxUntilTwelveMonth;
                case >= 13 and <= 24:
                    return _taxUntilTwentyFourMonth;
                case >= 24:
                    return _taxAboveTwentyFourMonth;
                default:
                    throw new Exception("Invalid investment time!");
            }
        }
        
    }
}
