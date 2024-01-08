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
    public class CdbController(IInvestimentService service) : ControllerBase
    {

        private readonly IInvestimentService _service = service;

        [HttpPost]
        [Route("CalculateInvestment")]
        public IActionResult CalculateInvestment(InvestmentDtoCreate investmentDtoCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = _service.CalculateInvestment(investmentDtoCreate);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
