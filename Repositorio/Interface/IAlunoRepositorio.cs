using webApi_Live.Models;

namespace webApi_Live.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAluno();

        Aluno BuscarAlunoPorId(int id);

        int InserirAluno(Aluno aluno);

        int AtualizarAluno(int id, Aluno aluno);

        void DeletarAluno(int id);
    }
}
