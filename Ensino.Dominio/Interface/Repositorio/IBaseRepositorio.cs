using Ensino.Dominio.Entidade;
using System.Collections.Generic;

namespace Ensino.Dominio.Interface.Repositorio
{
    public interface IBaseRepositorio<TEntity> where TEntity : EntidadeBase
    {
        IEnumerable<TEntity> Get();

        TEntity GetById(int id);

        TEntity Put(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(int id);
    }
}
