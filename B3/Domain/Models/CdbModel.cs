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
        private readonly static decimal _taxUntilSixMonth = 22.5M;
        private readonly static decimal _taxUntilTwelveMonth = 20M;
        private readonly static decimal _taxUntilTwentyFourMonth = 17.5M;
        private readonly static decimal _taxAboveTwentyFourMonth = 15M;
        private readonly static decimal _cdi = 0.9M;
        private readonly static decimal _tb = 108M;
        public CdbModel()
        {
        }

        public override InvestmentDtoCreateResult CalculateInvestment(decimal amount, int investmentTimeMonth)
        {
            InvestmentDtoCreateResult investmentDtoCreateResult = new();
            decimal grossAmount = amount;
            var cdiTbValue = GetCdiTbValue();

            for (int month = 1; month <= investmentTimeMonth; month++)
            {
                grossAmount *= cdiTbValue; 
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

        private static decimal GetCdiTbValue()
        {
            return 1 + (_cdi / 100) * (_tb / 100);
        }

        private static decimal GetTax(int investmentTime)
        {
            return investmentTime switch
            {
                >= 2 and <= 6 => _taxUntilSixMonth,
                >= 7 and <= 12 => _taxUntilTwelveMonth,
                >= 13 and <= 24 => _taxUntilTwentyFourMonth,
                >= 24 => _taxAboveTwentyFourMonth,
                _ => throw new ArgumentException("Invalid investment time!"),
            };
        }
        
    }
}
