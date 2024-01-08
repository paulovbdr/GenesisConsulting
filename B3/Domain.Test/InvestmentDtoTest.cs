using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    public class InvestmentDtoTest
    {
        [Fact]
        public void InvalidAmount()
        {
            var investmentDto = new InvestmentDtoCreate
            {
                Amount = -10,
                InvestmenTimeMonth = 12
            };

            var validationContext = new ValidationContext(investmentDto, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(investmentDto, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("The field Amount must be greater than 0,1.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void InvalidInvestimentTimeMonth()
        {
            var investmentDto = new InvestmentDtoCreate
            {
                Amount = 2400,
                InvestmenTimeMonth = 1
            };

            var validationContext = new ValidationContext(investmentDto, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(investmentDto, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("The field InvestmenTimeMonth must be greater than 2.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void ValidDto()
        {
            var investmentDto = new InvestmentDtoCreate
            {
                Amount = 6500,
                InvestmenTimeMonth = 15
            };

            var validationContext = new ValidationContext(investmentDto, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(investmentDto, validationContext, validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }
    }
}
