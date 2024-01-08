using Application.Controllers;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test
{
    public class CdbTest
    {
        private CdbController? _controller;
        private const string _url = "http://localhost:5000";

        [Fact(DisplayName = "Post calculate investment")]
        public void PostCalculateInvestment()
        {
            var serviceMock = new Mock<IInvestimentService>();
            var netAmount = 100;
            var grossAmount = 105;


            serviceMock.Setup(m => m.CalculateInvestment(It.IsAny<InvestmentDtoCreate>())).Returns(
                new InvestmentDtoCreateResult
                {
                    NetAmount = netAmount,
                    GrossAmount = grossAmount
                }
            );

            _controller = new CdbController(serviceMock.Object);

            Mock<IUrlHelper> url = new ();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(_url);
            _controller.Url = url.Object;

            var cdbCreate = new InvestmentDtoCreate { Amount = 100, InvestmenTimeMonth = 1 };

            var result = _controller.CalculateInvestment(cdbCreate);
            Xunit.Assert.NotNull(result);
        }

        [Fact(DisplayName = "Invalid amount")]
        public void PostInvalidAmount()
        {
            var serviceMock = new Mock<IInvestimentService>();
            var netAmount = 100;
            var grossAmount = 105;


            serviceMock.Setup(m => m.CalculateInvestment(It.IsAny<InvestmentDtoCreate>())).Returns(
                new InvestmentDtoCreateResult
                {
                    NetAmount = netAmount,
                    GrossAmount = grossAmount
                }
            );

            _controller = new CdbController(serviceMock.Object);
            _controller.ModelState.AddModelError("Amount", "Invalid amount");

            Mock<IUrlHelper> url = new();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(_url);
            _controller.Url = url.Object;

            var cdbCreate = new InvestmentDtoCreate { Amount = -10, InvestmenTimeMonth = 1 };

            var result = _controller.CalculateInvestment(cdbCreate);
            Xunit.Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "Invalid investment time")]
        public void PostInvalidInvestmentTimeMonth()
        {
            var serviceMock = new Mock<IInvestimentService>();
            var netAmount = 100;
            var grossAmount = 105;


            serviceMock.Setup(m => m.CalculateInvestment(It.IsAny<InvestmentDtoCreate>())).Returns(
                new InvestmentDtoCreateResult
                {
                    NetAmount = netAmount,
                    GrossAmount = grossAmount
                }
            );

            _controller = new CdbController(serviceMock.Object);
            _controller.ModelState.AddModelError("InvestmenTimeMonth", "Invalid investment time month");

            Mock<IUrlHelper> url = new();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(_url);
            _controller.Url = url.Object;

            var cdbCreate = new InvestmentDtoCreate { Amount = 100, InvestmenTimeMonth = 1 };

            var result = _controller.CalculateInvestment(cdbCreate);
            Xunit.Assert.True(result is BadRequestObjectResult);
        }
    }
}
