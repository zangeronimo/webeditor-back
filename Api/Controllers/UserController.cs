using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Domain.View;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<UserView>>
        Get(
            [FromServices] ShowUserService _show,
            [FromQuery(Name = "filter")] string filter
        )
        {
            try
            {
                var users = _show.Execute(filter);
                return Ok(users.Select(u => new UserView(u)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserView>>
        Post([FromServices] CreateUserService _create, [FromBody] User data)
        {
            try
            {
                var createdUser = await _create.Execute(data);
                return new UserView(createdUser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<UserView>>
        Put([FromServices] UpdateUserService _update, int Id,  [FromBody] User data)
        {
            try
            {
                if (Id != data.Id) {
                    return BadRequest("Usuário inválido.");
                }
                var updatedUser = await _update.Execute(data);
                return new UserView(updatedUser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<UserView>>
        Delete([FromServices] DeleteUserService _delete, int Id)
        {
            try
            {
                var deletedUser = await _delete.Execute(Id);
                return new UserView(deletedUser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
