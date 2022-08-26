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
        public Task Delete(int id);
        public Task<IEnumerable<TEntity>> Get();
        public Task<TEntity> GetById(int id);
        public Task Insert(TEntity data);
        public Task Update(TEntity data);
    }
}
