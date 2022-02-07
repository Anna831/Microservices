using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbount POST # Command Service");

            return Ok("Inbount test OK. Platforms Controlle. Command Service");
        }
    }
}