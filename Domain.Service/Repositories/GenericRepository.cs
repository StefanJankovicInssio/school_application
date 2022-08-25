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

        public void Delete(int id)
        {
            var data = dbSet.Find(id);
            dbSet.Remove(data);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity data)
        {
            dbSet.Add(data);
        }

        public void Update(TEntity data)
        {
            context.Entry(data).State = EntityState.Modified;
        }
    }
}
