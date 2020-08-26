using Ensino.Aplicacao.DTO;
using Ensino.Dominio.Entidade;

namespace Ensino.Aplicacao.Interface
{
    public interface IAppCargaDados : IAppBase<CargaDados, CargaDadosDto>
    {
        CargaDadosDto GetLastUpload();
    }
}
