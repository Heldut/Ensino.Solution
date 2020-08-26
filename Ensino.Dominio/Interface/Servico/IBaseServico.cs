using Ensino.Dominio.Entidade;
using System.Collections.Generic;

namespace Ensino.Dominio.Interface.Servico
{
    public interface IBaseServico<TEntidade> where TEntidade : EntidadeBase
    {
        IEnumerable<TEntidade> Get();

        TEntidade GetById(int id);

        TEntidade Put(TEntidade entity);

        void Update(TEntidade entity);

        void Delete(TEntidade entity);

        void DeleteById(int id);
    }
}
