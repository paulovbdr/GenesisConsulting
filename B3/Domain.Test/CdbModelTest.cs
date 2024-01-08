using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    public  class CdbModelTest
    {
        [Theory]
        [InlineData(500, 12, 561.54, 549.23)]
        [InlineData(1500, 18, 1785.29, 1735.36)]
        [InlineData(2000, 6, 2119.51, 2092.62)] 
        public void CalculateInvestment(
        decimal initialAmount, int investmentTime, decimal expectedGrossAmount, decimal expectedNetAmount)
        {
            var cdbModel = new CdbModel();

            var result = cdbModel.CalculateInvestment(initialAmount, investmentTime);

            Assert.NotNull(result);
            Assert.Equal(expectedGrossAmount, result.GrossAmount, 2);
            Assert.Equal(expectedNetAmount, result.NetAmount, 2);
        }

        [Theory]
        [InlineData(-600, 3)]
        [InlineData(0, 9)]
        [InlineData(300, 1)]
        [InlineData(1200, -2)]
        public void Invalid(decimal initialAmount, int investmentTime)
        {
            var cdbModel = new CdbModel();

            Assert.Throws<ArgumentException>(() => cdbModel.CalculateInvestment(initialAmount, investmentTime));
        }
    }
}
