using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HospitalRepos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalRepos.Implementation
{
    public class GenRepoImp<T>:IGenRepo<T>,IDisposable where T:class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        
        public GenRepoImp(ApplicationDbContext cxt)
        {
            _context = cxt;
            _dbSet=_context.Set<T>();

        }

        
      public void Add(T entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);

            }
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();  
                }
            }
            disposed = true;
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, 
            IOrderedQueryable<T>> order_by = null, string Include_Properties = "")
        {
            IQueryable<T> qrbl = _dbSet;
            if (filter != null)
            {
                qrbl = qrbl.Where(filter);
            }

            if(order_by != null)
            {
                return order_by(qrbl).ToList();
            }
            return qrbl.ToList();

        }

        public T? GetById(Func<T, bool> ex)
        {

            T? val= _dbSet.FirstOrDefault(ex);
            
            if (val != null)
            {
                return val;
            }
            return null;
        }

        public void Remove(Func<T,bool> ex)
        {
            var val = _dbSet.FirstOrDefault(ex);
            if (val != null) {
                _dbSet.Remove(val);
            }
        }

        public T Update(Func<T, bool> ex)
        {
           
            T hld = _dbSet.FirstOrDefault(ex);
            return hld;

            
        }
    }
}
