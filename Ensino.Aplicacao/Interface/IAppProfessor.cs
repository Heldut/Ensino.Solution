using Ensino.Aplicacao.DTO;
using Ensino.Dominio.Entidade;

namespace Ensino.Aplicacao.Interface
{
    public interface IAppProfessor : IAppBase<Professor, ProfessorDto>
    {
        ProfessorDto GetAllByNome(string nome);
    }
}
