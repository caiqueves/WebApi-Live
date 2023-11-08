using webApi_Live.Models;

namespace webApi_Live.Servicos.Interface
{
    public interface IAlunoServico
    {
        List<Aluno> buscarAluno();

        Aluno buscarAlunoId(int id);

        int inserirAluno(Aluno aluno);

        int Atualizar(int id, Aluno aluno);

        void DeletarAluno(int id);
    }
}
