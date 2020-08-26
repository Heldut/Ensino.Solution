using System;
using System.Linq;
using Ensino.Dominio.Entidade;
using Ensino.Dominio.Interface.Repositorio;
using Ensino.Infraestrutura.Data.Contexto;
using System.Collections.Generic;

namespace Ensino.Infraestrutura.Data.Repositorio
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : EntidadeBase
    {
        protected readonly ContextoDB _contexto;

        public BaseRepositorio(ContextoDB contexto) : base()
        {
            _contexto = contexto;
        }

        public void Delete(TEntity entity)
        {
            _contexto.InitTransacao();
            _contexto.Set<TEntity>().Remove(entity);
            _contexto.SendChanges();
        }

        public void DeleteById(int id)
        {
            var entidade = GetById(id);
            if (entidade != null)
            {
                _contexto.InitTransacao();
                _contexto.Set<TEntity>().Remove(entidade);
                _contexto.SendChanges();
            }
        }

        public IEnumerable<TEntity> Get()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public TEntity Put(TEntity entity)
        {
            _contexto.InitTransacao();
            var id = _contexto.Set<TEntity>().Add(entity).Entity;
            _contexto.SendChanges();
            return id;
        }

        public void Update(TEntity entity)
        {
            try
            {
                _contexto.Update(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
