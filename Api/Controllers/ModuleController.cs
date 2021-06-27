using System;
using System.Collections.Generic;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly ShowModuleService _showModuleService;

        public ModuleController(ShowModuleService showModuleService)
        {
            _showModuleService = showModuleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Module>>
        Get([FromQuery(Name = "filter")] string filter)
        {
            try
            {
                var modules = _showModuleService.Execute(filter);
                return Ok(modules);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
