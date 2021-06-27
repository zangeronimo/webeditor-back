using System;
using System.Collections.Generic;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ShowCompanyService _showCompanyService;

        public CompanyController(ShowCompanyService showCompanyService)
        {
            _showCompanyService = showCompanyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>>
        Get([FromQuery(Name = "filter")] string filter)
        {
            try
            {
                var companies = _showCompanyService.Execute(filter);
                return Ok(companies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
