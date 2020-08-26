using AutoMapper;
using Ensino.Aplicacao.DTO;
using Ensino.Aplicacao.Interface;
using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Servico;

namespace Ensino.Aplicacao.Servico
{
    public class CargaDadosAppServico : BaseAppServico<CargaDados, CargaDadosDto>, IAppCargaDados
    {
        protected readonly ICargaDadosServico _servico;
        protected readonly IMapper _iMapper;

        public CargaDadosAppServico(IMapper iMapper, ICargaDadosServico servico) : base(iMapper, servico)
        {
            _servico = servico;
            _iMapper = iMapper;
        }

        public CargaDadosDto GetLastUpload()
        {
            return _iMapper.Map<CargaDadosDto>(_servico.GetLastUpload());
        }
    }
}
