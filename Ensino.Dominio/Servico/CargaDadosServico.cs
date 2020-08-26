using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Dominio.Interface.Servico;
using System.Collections.Generic;

namespace Ensino.Dominio.Servico
{
    public class CargaDadosServico : BaseServico<CargaDados>, ICargaDadosServico
    {
        protected readonly ICargaDadosRepositorio _repositorioCargaDados;
        public CargaDadosServico(ICargaDadosRepositorio repositorio) : base(repositorio)
        {
            _repositorioCargaDados = repositorio;
        }

        public CargaDados GetLastUpload()
        {
            return _repositorioCargaDados.GetLastUpload();
        }
    }
}
