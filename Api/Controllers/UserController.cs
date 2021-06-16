using Domain.Models.Webeditor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        [HttpGet]
        public Users Get()
        {
            return new Users();
        }
    }
}