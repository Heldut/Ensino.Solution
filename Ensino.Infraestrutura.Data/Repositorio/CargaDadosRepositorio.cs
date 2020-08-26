using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Infraestrutura.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ensino.Infraestrutura.Data.Repositorio
{
    public class CargaDadosRepositorio : BaseRepositorio<CargaDados>, ICargaDadosRepositorio
    {
        public CargaDadosRepositorio(ContextoDB contexto) : base(contexto)
        {
        }

        public CargaDados GetLastUpload()
        {
            return _contexto.Set<CargaDados>()
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();
        }
    }
}
