using Microsoft.AspNetCore.Mvc;
using System;
using TheHome.Models;

namespace TheHome.Controllers
{
    [Produces("application/json")]
    [Route("api/Lifecycle")]
    public class LifecycleController : Controller
    {
        // POST: api/Lifecycle
        [HttpPost]
        public ActionResult Post([FromBody]ExecutionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            switch (request.LifeCycle)
            {
                case Common.Enums.LifeCycleEnum.INSTALL:
                    throw new NotImplementedException("Install lifecycle");
                case Common.Enums.LifeCycleEnum.UPDATE:
                    throw new NotImplementedException("Update lifecycle");
                case Common.Enums.LifeCycleEnum.UNINSTALL:
                    throw new NotImplementedException("Uninstall lifecycle");
                case Common.Enums.LifeCycleEnum.EVENT:
                    throw new NotImplementedException("Event lifecycle");
                case Common.Enums.LifeCycleEnum.PING:
                    return HandlePing((PingRequest)request);
                case Common.Enums.LifeCycleEnum.CONFIGURATION:
                    throw new NotImplementedException("Configuration lifecycle");
                case Common.Enums.LifeCycleEnum.OAUTH_CALLBACK:
                    throw new NotImplementedException("OauthCallback lifecycle");
                default:
                    break;
            }

            return Ok(request);
        }

        private ActionResult HandlePing(PingRequest request)
        {
            var response = new PingResponse() { PingData = request.PingData };
            return Ok(response);
        }
    }
}
