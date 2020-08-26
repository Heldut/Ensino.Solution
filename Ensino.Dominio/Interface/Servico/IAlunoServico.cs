using Ensino.Dominio.Entidade;
using System.Collections.Generic;

namespace Ensino.Dominio.Interface.Servico
{
    public interface IAlunoServico : IBaseServico<Aluno>
    {
        IEnumerable<Aluno> GetAllByIdProfessor(int idProfessor);

        IEnumerable<Aluno> GetAll();
    }
}
