using System;
using System.Collections.Generic;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ShowUserService _showUserService;
        public UserController(ShowUserService showUserService)
        {
            _showUserService = showUserService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery(Name = "filter")] string filter)
        {
            try
            {
                var users = _showUserService.Execute(filter);
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}