using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRepos.Interfaces
{
    public interface IGenRepo<B>:IDisposable
    {
        public B GetById(Func<B, bool> ex);
        public void Add(B b);
        public B Update(Func<B, bool> ex);
        public void Remove(Func<B, bool> ex);
        public List<B> GetAll(Expression<Func<B,bool>> filter=null, Func<IQueryable<B>,
            IOrderedQueryable<B>> order_by=null, string Include_Properties="");

    }
}
