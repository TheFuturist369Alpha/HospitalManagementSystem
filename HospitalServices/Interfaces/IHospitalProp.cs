using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using HospitalModels;
using HospitalRepos.Implementation;
using ViewModels;

namespace HospitalServices.Interfaces
{
    public interface IHospitalProp
    {

        public PageUtil<HospitalViewModel> GetAll(int pageNumber, int pageSize);
        public void DeleteHospitalView(Guid id);
        public HospitalViewModel GetHospitalViewModel(Guid id);
        public void UpdateHospital(HospitalViewModel hp);
        public void InsertNewHospital(HospitalViewModel info);

    }
}
