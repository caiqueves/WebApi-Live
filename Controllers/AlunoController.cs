using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webApi_Live.Models;
using webApi_Live.Servicos.Interface;

namespace webApi_Live.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        private List<Aluno> alunos = new List<Aluno>();
        private readonly IAlunoServico _alunoServico;

        public AlunoController(IAlunoServico alunoServico) 
        { 
            _alunoServico = alunoServico;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_alunoServico.buscarAluno());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {

            var aluno = _alunoServico.buscarAlunoId(id);
            return Ok(aluno);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Inserir([FromBody] Aluno aluno)
        {
            _alunoServico.inserirAluno(aluno);
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Aluno entidade)
        {
            _alunoServico.Atualizar(id, entidade);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            _alunoServico.DeletarAluno(id);
            return NoContent();
        }
    }
}