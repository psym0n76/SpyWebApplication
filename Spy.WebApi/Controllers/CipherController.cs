using Microsoft.AspNetCore.Mvc;
using Spy.Library.Services;

namespace Spy.WebApi.Controllers
{
    [Route("api/cipher")]
    [ApiController]
    public class CipherController : ControllerBase
    {
        private readonly ICipherService _cipherService;

        public CipherController(ICipherService cipherService)
        {
            _cipherService = cipherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("decode")]
        public IActionResult Get(string message, string spyName)
        {
            if (!ControllerValidation.Parse(message, spyName))
                return StatusCode(400, "Bad Data: message and spyname must be populated.");

            var response = _cipherService.Decode(message, spyName);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
