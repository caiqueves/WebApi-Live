using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Runtime.Serialization.Formatters;
using webApi_Live.Data;
using webApi_Live.Models;
using webApi_Live.Repositorio.Interface;


namespace webApi_Live.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly AppDbContext _dbContext;

        public AlunoRepositorio(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public List<Aluno> BuscarAluno()
        {
            return _dbContext.Aluno.ToList();
        }

        public Aluno BuscarAlunoPorId(int id)
        {
            return _dbContext.Aluno.FirstOrDefault(c => c.Id == id);
        }

        public int InserirAluno(Aluno aluno)
        {
            try
            {
                _dbContext.Add(aluno);
                _dbContext.SaveChanges();

                return 1;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public int AtualizarAluno(int id, Aluno aluno)
        {
            try
            {
                var tbAluno = _dbContext.Aluno.FirstOrDefault(d => d.Id == aluno.Id);

                tbAluno.Id = aluno.Id;
                tbAluno.Nome = aluno.Nome;
                tbAluno.Serie = aluno.Serie;
                tbAluno.Professor = aluno.Professor;


                _dbContext.Update(tbAluno);
                _dbContext.SaveChanges();

                return 1;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public void DeletarAluno(int id)
        {
            try
            {
                var deAluno = _dbContext.Aluno.FirstOrDefault(d => d.Id == id);

                _ = _dbContext.Remove(deAluno);
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
    }
}
