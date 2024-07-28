using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Response;

namespace TaskSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        // Acess to ViaCepIntegration
        private readonly IViaCepIntegration _integration;
        public CepController(IViaCepIntegration integration)
        {
            _integration = integration;
        }

        // Method
        [HttpGet]
        public async Task<ActionResult<ViaCepResponse>> ListDataAddress(string cep)
        {
            var responseData = await _integration.GetViaCepData(cep);
            if (responseData == null)
            {
                return BadRequest("CEP not found");
            }
            return Ok(responseData);
        }
    }
}
