using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>>
        Get(
            [FromServices] ShowUserService _show,
            [FromQuery(Name = "filter")] string filter
        )
        {
            try
            {
                var users = _show.Execute(filter);
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>>
        Post([FromServices] CreateUserService _create, [FromBody] User data)
        {
            try
            {
                var createdUser = await _create.Execute(data);
                return createdUser;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<User>>
        Put([FromServices] UpdateUserService _update, int Id,  [FromBody] User data)
        {
            try
            {
                if (Id != data.Id) {
                    return BadRequest("Usuário inválido.");
                }
                var updatedUser = await _update.Execute(data);
                return updatedUser;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<User>>
        Delete([FromServices] DeleteUserService _delete, int Id)
        {
            try
            {
                var deletedUser = await _delete.Execute(Id);
                return deletedUser;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
