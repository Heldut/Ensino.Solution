using Ensino.Dominio.Entidade;
using System.Collections.Generic;

namespace Ensino.Dominio.Interface.Repositorio
{
    public interface IAlunoRepositorio : IBaseRepositorio<Aluno>
    {
        IEnumerable<Aluno> GetAllByIdProfessor(int idProfessor);

        IEnumerable<Aluno> GetAll();
    }
}
