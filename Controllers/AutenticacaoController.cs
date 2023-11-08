using Microsoft.AspNetCore.Mvc;
using webApi_Live.Servicos.Interface;

namespace webApi_Live.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        public readonly ITokenGeneratorServico _tokenGeneratorServico;

        public AutenticacaoController(ITokenGeneratorServico tokenGeneratorServico)
        {
            _tokenGeneratorServico = tokenGeneratorServico;
        }

        [HttpPost("gerar-token")]
        public IActionResult GerarToken()
        {
            var tokenString = _tokenGeneratorServico.GenerateFixedToken();

            return Ok(new { token = tokenString });
        }
    }
}