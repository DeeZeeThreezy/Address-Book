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
        void Add(TEntity newEntity);
        void Update(TEntity updatedEntity);
        void Delete(TEntity entity);
    }
}
