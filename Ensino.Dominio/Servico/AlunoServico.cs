using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Dominio.Interface.Servico;
using System.Collections.Generic;

namespace Ensino.Dominio.Servico
{
    public class AlunoServico : BaseServico<Aluno>, IAlunoServico
    {
        protected readonly IAlunoRepositorio _repositorioAluno;
        public AlunoServico(IAlunoRepositorio repositorio) : base(repositorio)
        {
            _repositorioAluno = repositorio;
        }

        public IEnumerable<Aluno> GetAllByIdProfessor(int idProfessor)
        {
            return _repositorioAluno.GetAllByIdProfessor(idProfessor);
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _repositorioAluno.GetAll();
        }
    }
}
