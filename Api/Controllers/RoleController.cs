using System;
using System.Collections.Generic;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ShowRoleService _showRoleService;

        public RoleController(ShowRoleService showRoleService)
        {
            _showRoleService = showRoleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>>
        Get([FromQuery(Name = "filter")] string filter)
        {
            try
            {
                var roles = _showRoleService.Execute(filter);
                return Ok(roles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
