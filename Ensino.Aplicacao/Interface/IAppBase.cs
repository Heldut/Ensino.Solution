using Ensino.Aplicacao.DTO;
using Ensino.Dominio.Entidade;
using System.Collections.Generic;

namespace Ensino.Aplicacao.Interface
{
    public interface IAppBase<TEntity, TEntidadeDTO> where TEntity : EntidadeBase where TEntidadeDTO : BaseDto
    {
        IEnumerable<TEntidadeDTO> Get();

        TEntity GetById(int id);

        TEntity Put(TEntidadeDTO entityDto);

        void Update(TEntidadeDTO entityDto);

        void Delete(TEntidadeDTO entityDto);

        void DeleteById(int id);
    }
}
