using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webApi_Live.Models;

namespace webApi_Live.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinhaEntidadeController : ControllerBase
    {
        private List<Crud> entidades = new List<Crud>();

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(entidades);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var entidade = entidades.FirstOrDefault(e => e.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }
            return Ok(entidade);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Inserir([FromBody] Crud entidade)
        {
            // Lógica de inserção aqui
            // Verifique a autenticação do token antes de prosseguir
            entidades.Add(entidade);
            return CreatedAtAction(nameof(ObterPorId), new { id = entidade.Id }, entidade);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Crud entidade)
        {
            // Lógica de atualização aqui
            // Verifique a autenticação do token antes de prosseguir
            var existing = entidades.FirstOrDefault(e => e.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Propriedade = entidade.Propriedade; // Atualize as propriedades conforme necessário
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            // Lógica de exclusão aqui
            // Verifique a autenticação do token antes de prosseguir
            var entidade = entidades.FirstOrDefault(e => e.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }
            entidades.Remove(entidade);
            return NoContent();
        }
    }
}