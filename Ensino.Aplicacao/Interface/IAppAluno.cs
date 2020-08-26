using Ensino.Aplicacao.DTO;
using Ensino.Dominio.Entidade;
using System.Collections.Generic;

namespace Ensino.Aplicacao.Interface
{
    public interface IAppAluno : IAppBase<Aluno, AlunoDto>
    {
        IEnumerable<AlunoDto> GetAllByIdProfessor(int idProfessor);

        IEnumerable<AlunoDto> GetAll();
    }
}
