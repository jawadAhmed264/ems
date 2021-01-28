using ems.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace ems.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private emsDbEntities _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new emsDbEntities();
            table = _context.Set<T>();
        }
        public GenericRepository(emsDbEntities _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        [EnableQuery]
        public IQueryable<T> GetAll()
        {
            return table.AsQueryable();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public int Save()
        {
            int num=_context.SaveChanges();
            return num;
        }
    }
}
