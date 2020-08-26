using Ensino.Dominio.Entidade;

namespace Ensino.Dominio.Interface.Repositorio
{
    public interface IProfessorRepositorio : IBaseRepositorio<Professor>
    {
        Professor GetAllByNome(string nome);
    }
}
