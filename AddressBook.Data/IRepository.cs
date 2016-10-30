using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public interface IRepository<TId, TEntity>
    {
        TEntity GetById(TId id);
        IEnumerable<TEntity> Get();
        TEntity Add(TEntity newEntity);
        TEntity Update(TEntity updatedEntity);
        void Delete(TEntity entity);
    }
}
