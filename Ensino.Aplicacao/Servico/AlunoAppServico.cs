using AutoMapper;
using Ensino.Aplicacao.DTO;
using Ensino.Aplicacao.Interface;
using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Servico;
using System.Collections.Generic;

namespace Ensino.Aplicacao.Servico
{
    public class AlunoAppServico : BaseAppServico<Aluno, AlunoDto>, IAppAluno
    {
        protected readonly IAlunoServico _servico;
        protected readonly IMapper _iMapper;

        public AlunoAppServico(IMapper iMapper, IAlunoServico servico) : base(iMapper, servico)
        {
            _servico = servico;
            _iMapper = iMapper;
        }

        public IEnumerable<AlunoDto> GetAllByIdProfessor(int idProfessor)
        {
            return _iMapper.Map<IEnumerable<AlunoDto>>(_servico.GetAllByIdProfessor(idProfessor));
        }

        public IEnumerable<AlunoDto> GetAll()
        {
            return _iMapper.Map<IEnumerable<AlunoDto>>(_servico.GetAll());
        }
    }
}
