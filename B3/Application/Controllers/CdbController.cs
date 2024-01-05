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

        private IInvestimentService _service;

        public CdbController(IInvestimentService service)
        {
            _service = service;
        }

        [HttpPost]
        public InvestmentDtoCreateResult CalculateInvestment(InvestmentDtoCreate investmentDtoCreate)
        {
            try
            {
                var result = _service.CalculateInvestment(investmentDtoCreate);
                return result;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
