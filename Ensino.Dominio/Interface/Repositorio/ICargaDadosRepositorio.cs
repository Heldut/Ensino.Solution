using Ensino.Dominio.Entidade;
using System.Collections.Generic;


namespace Ensino.Dominio.Interface.Repositorio
{
    public interface ICargaDadosRepositorio : IBaseRepositorio<CargaDados>
    {
        CargaDados GetLastUpload();
    }
}
