using Ensino.Dominio.Entidade;
using System.Collections.Generic;

namespace Ensino.Dominio.Interface.Servico
{
    public interface ICargaDadosServico : IBaseServico<CargaDados>
    {
        CargaDados GetLastUpload();
    }
}
