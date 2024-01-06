using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdbController : ControllerBase
    {

        private readonly IInvestimentService _service;

        public CdbController(IInvestimentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CalculateInvestment")]
        public InvestmentDtoCreateResult CalculateInvestment(InvestmentDtoCreate investmentDtoCreate)
        {
            var result = _service.CalculateInvestment(investmentDtoCreate);
            return result;
        }
    }
}
