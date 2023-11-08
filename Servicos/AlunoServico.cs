using webApi_Live.Models;
using webApi_Live.Repositorio;
using webApi_Live.Repositorio.Interface;
using webApi_Live.Servicos.Interface;

namespace webApi_Live.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoServico(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public List<Aluno> buscarAluno()
        {
            return _alunoRepositorio.BuscarAluno();
        }

        public Aluno buscarAlunoId(int id)
        {
            return _alunoRepositorio.BuscarAlunoPorId(id);
        }

        public int inserirAluno(Aluno aluno)
        {
            return _alunoRepositorio.InserirAluno(aluno);
        }

        public int Atualizar(int id, Aluno aluno)
        {
            return _alunoRepositorio.AtualizarAluno(id, aluno);
        }

        public void DeletarAluno(int id)
        {
            _alunoRepositorio.DeletarAluno(id);
        }

    }
}
