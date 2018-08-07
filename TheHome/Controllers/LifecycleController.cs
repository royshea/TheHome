using Microsoft.AspNetCore.Mvc;
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
            return Ok(request);
        }
    }
}
