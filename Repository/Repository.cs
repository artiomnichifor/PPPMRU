using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using System.Diagnostics;

namespace Repository.Implementation
{
    public class Repository : IRepository
    {
        private EmployeeManagementContext context;
        public Repository(EmployeeManagementContext context)
        {
            this.context = context;
        }

        public IList<T> GetAll<T>() where T : EntityBase
        {
            
            return context.Set<T>().ToList();
        }

        public void Create<T>(T entity) where T : EntityBase
        {
            var item = context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : EntityBase
        {
            context.Set<T>().Remove(entity);
        }

        public T GetById<T>(long id) where T : EntityBase
        {
            return context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public void Update<T>(T entity) where T : EntityBase
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

