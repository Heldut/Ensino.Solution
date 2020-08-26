using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Dominio.Interface.Servico;

namespace Ensino.Dominio.Servico
{
    public class ProfessorServico : BaseServico<Professor>, IProfessorServico
    {
        protected readonly IProfessorRepositorio _repositorioProfessor;
        public ProfessorServico(IProfessorRepositorio repositorio) : base(repositorio)
        {
            _repositorioProfessor = repositorio;
        }

        public Professor GetAllByNome(string nome)
        {
            return _repositorioProfessor.GetAllByNome(nome);
        }
    }
}
