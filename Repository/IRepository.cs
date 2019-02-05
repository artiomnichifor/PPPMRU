using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Interfaces
{
    public interface IRepository : IDisposable
    {
        IList<T> GetAll<T>() where T : EntityBase;

        T GetById<T>(long id) where T : EntityBase;

        void Create<T>(T entity) where T : EntityBase;

        void Delete<T>(T entity) where T : EntityBase;

        void Update<T>(T entity) where T : EntityBase;

        void Save();

    }
}
