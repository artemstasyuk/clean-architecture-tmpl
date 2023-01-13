using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        protected IActionResult Error()
        {
            return Problem();
        }
    }
}