using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace Server.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/Registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RegistrationData value)
        {
            // we can perform server side validation
            // value.CheckRules();
            if (value.HasErrors())
            {
                return BadRequest();
            }
            // TODO: Save data to database
            return Created("api/registration", value);
        }
    }
}
