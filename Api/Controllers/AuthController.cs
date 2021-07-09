using System;
using System.Linq;
using Domain.Models.Webeditor;
using Domain.Services.Webeditor;
using Domain.View.Webeditor;
using Infra.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public IConfiguration Configuration { get; }
        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        public ActionResult<AuthView> Post(
            [FromServices] AuthService _auth,
            [FromBody] Auth model)
        {
          try
          {
            var authResult = _auth.Execute(model, Configuration.GetConnectionString("Secret"));
            return authResult;
          }
          catch (Exception e) {
            return BadRequest(e.Message);
          }
          
        }
    }
}