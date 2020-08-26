using AutoMapper;
using System.Collections.Generic;
using Ensino.Aplicacao.DTO;
using Ensino.Aplicacao.Interface;
using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Servico;

namespace Ensino.Aplicacao.Servico
{
    public class BaseAppServico<TEntidade, TEntidadeDTO> : IAppBase<TEntidade, TEntidadeDTO> where TEntidade : EntidadeBase where TEntidadeDTO : BaseDto
    {
        protected readonly IBaseServico<TEntidade> _servico;
        protected readonly IMapper _iMapper;

        public BaseAppServico(IMapper iMapper, IBaseServico<TEntidade> servico) : base()
        {
            _iMapper = iMapper;
            _servico = servico;
        }

        public void Delete(TEntidadeDTO entityDto)
        {
            _servico.Delete(_iMapper.Map<TEntidade>(entityDto));
        }

        public void DeleteById(int id)
        {
            _servico.DeleteById(id);
        }

        public IEnumerable<TEntidadeDTO> Get()
        {
            return _iMapper.Map<IEnumerable<TEntidadeDTO>>(_servico.Get());
        }

        public TEntidade GetById(int id)
        {
            return _iMapper.Map<TEntidade>(_servico.GetById(id));
        }

        public TEntidade Put(TEntidadeDTO entityDto)
        {
            return _servico.Put(_iMapper.Map<TEntidade>(entityDto));
        }

        public void Update(TEntidadeDTO entityDto)
        {
            _servico.Update(_iMapper.Map<TEntidade>(entityDto));
        }
    }
}
