using Ensino.Dominio.Entidade;
using System.Collections.Generic;
using Ensino.Dominio.Interface.Servico;
using Ensino.Dominio.Interface.Repositorio;


namespace Ensino.Dominio.Servico
{
    public class BaseServico<TEntidade> : IBaseServico<TEntidade> where TEntidade : EntidadeBase
    {
        protected readonly IBaseRepositorio<TEntidade> _repositorio;
        public BaseServico(IBaseRepositorio<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public void DeleteById(int id)
        {
            _repositorio.DeleteById(id);
        }

        public void Delete(TEntidade entity)
        {
            _repositorio.Delete(entity);
        }

        public IEnumerable<TEntidade> Get()
        {
            return _repositorio.Get();
        }

        public TEntidade GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public TEntidade Put(TEntidade entity)
        {
            return _repositorio.Put(entity);
        }

        public void Update(TEntidade entity)
        {
            _repositorio.Update(entity);
        }
    }
}
