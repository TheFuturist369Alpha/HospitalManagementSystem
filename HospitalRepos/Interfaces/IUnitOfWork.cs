
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRepos.Interfaces
{
    public interface IUnitOfWork
    {
        IGenRepo<B> GenericRepo<B>() where B : class;
        void Save();
    }
}
