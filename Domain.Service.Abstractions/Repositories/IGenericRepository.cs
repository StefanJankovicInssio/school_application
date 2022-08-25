using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        public void Delete(int id);
        public IEnumerable<TEntity> Get();
        public TEntity GetById(int id);
        public void Insert(TEntity data);
        public void Update(TEntity data);
    }
}
