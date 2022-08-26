using Application.Data;
using Domain.Service.Repositories;
using Domen.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task Delete(int id)
        {
            var data = await dbSet.FindAsync(id);
            dbSet.Remove(data);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Insert(TEntity data)
        {
            await dbSet.AddAsync(data);
        }

        public async Task Update(TEntity data)
        {
            context.Entry(data).State = EntityState.Modified;
        }
    }
}
