using AutoMapper;
using Ensino.Aplicacao.DTO;
using Ensino.Aplicacao.Interface;
using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Servico;
using System.Collections.Generic;

namespace Ensino.Aplicacao.Servico
{
    public class ProfessorAppServico : BaseAppServico<Professor, ProfessorDto>, IAppProfessor
    {
        protected readonly IProfessorServico _servico;
        protected readonly IMapper _iMapper;

        public ProfessorAppServico(IMapper iMapper, IProfessorServico servico) : base(iMapper, servico)
        {
            _servico = servico;
            _iMapper = iMapper;
        }

        public ProfessorDto GetAllByNome(string nome)
        {
            return _iMapper.Map<ProfessorDto>(_servico.GetAllByNome(nome));
        }
    }
}
