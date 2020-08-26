using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Infraestrutura.Data.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace Ensino.Infraestrutura.Data.Repositorio
{
    public class ProfessorRepositorio : BaseRepositorio<Professor>, IProfessorRepositorio
    {
        public ProfessorRepositorio(ContextoDB contexto) : base(contexto)
        {
        }

        public Professor GetAllByNome(string nome)
        {
            return _contexto.Professors.Where(x => x.Nome == nome).FirstOrDefault();
        }
    }
}
