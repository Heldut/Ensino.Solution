using Ensino.Dominio.Entidade;

namespace Ensino.Dominio.Interface.Servico
{
    public interface IProfessorServico : IBaseServico<Professor>
    {
        Professor GetAllByNome(string nome);
    }
}
