using Microsoft.AspNetCore.Mvc;

namespace BeamlineX.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
    }
}
