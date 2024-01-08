using Domain.Dtos;
using Domain.Interfaces.Services;
using Moq;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Test
{
    public class CdbServiceTest : CdbTestInfos
    {
        private IInvestimentService? _service;
        private Mock<IInvestimentService>? _serviceMock;

        [Fact(DisplayName = "Test CalculateInvestment.")]
        public void ExecuteCalculateInvestmentMock()
        {
            _serviceMock = new Mock<IInvestimentService>();
            _serviceMock.Setup(m => m.CalculateInvestment(cdbDtoCreate)).Returns(cdbDtoCreateResult);
            _service = _serviceMock.Object;

            var result = _service.CalculateInvestment(cdbDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(cdbDtoCreateResult.GrossAmount, result.GrossAmount);
            Assert.Equal(cdbDtoCreateResult.NetAmount, cdbDtoCreateResult.NetAmount);
        }

        [Fact(DisplayName = "Test CalculateInvestment invalid amount.")]
        public void ExecuteInvalidAmountMock()
        {
            _serviceMock = new Mock<IInvestimentService>();
            _serviceMock.Setup(m => m.CalculateInvestment(cdbDtoCreateInvalidAmount)).Throws(new ArgumentException("Invalid amount!"));
            _service = _serviceMock.Object;

            Assert.Throws<ArgumentException>(() => _service.CalculateInvestment(cdbDtoCreateInvalidAmount));
        }

        [Fact(DisplayName = "Test CalculateInvestment invalid investment time.")]
        public void ExecuteInvalidInvestmentTimeMock()
        {
            _serviceMock = new Mock<IInvestimentService>();
            _serviceMock.Setup(m => m.CalculateInvestment(cdbDtoCreateInvalidInvestmentTime)).Throws(new ArgumentException("Invalid investment time!"));
            _service = _serviceMock.Object;

            Assert.Throws<ArgumentException>(() => _service.CalculateInvestment(cdbDtoCreateInvalidInvestmentTime));
        }

        [Theory]
        [InlineData(500, 12, 561.54, 549.23)]
        [InlineData(1500, 18, 1785.29, 1735.36)]
        [InlineData(2000, 6, 2119.51, 2092.62)]
        public void ExecuteCalculateInvestment(
        decimal amount, int investmentTime, decimal expectedGrossAmount, decimal expectedNetAmount)
        {
            var cdbService = new CdbService();
            var investmentDtoCreate = new InvestmentDtoCreate { Amount = amount, InvestmenTimeMonth = investmentTime };

            var result = cdbService.CalculateInvestment(investmentDtoCreate);

            Assert.NotNull(result);
            Assert.Equal(expectedGrossAmount, result.GrossAmount, 2);
            Assert.Equal(expectedNetAmount, result.NetAmount, 2);
        }

        [Theory]
        [InlineData(0, 8)] 
        [InlineData(600, 1)]
        public void ExecuteInvalid(
        decimal amount, int investmentTime)
        {
            // Arrange
            var cdbService = new CdbService();
            var investmentDtoCreate = new InvestmentDtoCreate { Amount = amount, InvestmenTimeMonth = investmentTime };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => cdbService.CalculateInvestment(investmentDtoCreate));
        }

        
    }
}
