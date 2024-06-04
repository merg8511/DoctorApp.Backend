using DoctorApp.Services.API.Errores;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.Services.API.Controllers
{
    [Route("errores/{codigo}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int codigo)
        {
            return new ObjectResult(new ApiErrorResponse(codigo));
        }
    }
}
