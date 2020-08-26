using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Infraestrutura.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ensino.Infraestrutura.Data.Repositorio
{
    public class AlunoRepositorio : BaseRepositorio<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(ContextoDB contexto) : base(contexto)
        {
        }

        public IEnumerable<Aluno> GetAllByIdProfessor(int idProfessor)
        {
            return _contexto.Alunos.Where(x => x.ProfessorId == idProfessor)
                    .Include(b => b.Professor)
                    .ToList();
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _contexto.Alunos
                    .Include(b => b.Professor)
                    .ToList();
        }
    }
}
