using HospitalModels;
using HospitalRepos.Implementation;
using HospitalRepos.Interfaces;
using HospitalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using ViewModels;


namespace HospitalServices.Implementations
{
    public class HospitalService : IHospitalProp
    {
        private readonly IUnitOfWork _unitOfWork;
        public HospitalService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public PageUtil<HospitalViewModel> GetAll(int pageNumber, int pageSize)
        {
            HospitalViewModel hvm = new HospitalViewModel();
            int count;
            List<HospitalViewModel> viewList= new List<HospitalViewModel>();
            try
            {
                int ExcludedRecords = pageNumber * pageSize - pageSize;
                var models = _unitOfWork.GenericRepo<HospitalProp>().GetAll()
                    .Skip(ExcludedRecords).Take(pageSize).ToList();
                count = _unitOfWork.GenericRepo<HospitalProp>().GetAll().ToList().Count;
                viewList = ToHospitalVMList(models);
            }
            catch(Exception ex)
            {
                throw;
            }

            return new PageUtil<HospitalViewModel>()
            {
                Data = viewList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageCount = count


            };

        }

        private List<HospitalViewModel> ToHospitalVMList(List<HospitalProp> Hospitals) {

            return Hospitals.Select(x => new HospitalViewModel(x)).ToList();
        
        }

        public void DeleteHospitalView(Guid id)
        {
            _unitOfWork.GenericRepo<HospitalProp>().Remove(x=>x.Id==id);
            _unitOfWork.Save();
        }
         
        public HospitalViewModel GetHospitalViewModel(Guid id)
        {
            HospitalProp main = _unitOfWork.GenericRepo<HospitalProp>().GetById(x => x.Id == id);

            return new HospitalViewModel(main);
        }

        public void InsertNewHospital(HospitalViewModel info)
        {
            _unitOfWork.GenericRepo<HospitalProp>().Add(info.ToHospitalProp());
            _unitOfWork.Save();
        }

        public void UpdateHospital(HospitalViewModel hp)
        {
            HospitalProp hospitalProp = hp.ToHospitalProp();

            HospitalProp prop = _unitOfWork.GenericRepo<HospitalProp>().Update( x => x.Id == hp.Id);
            prop.Address=hospitalProp.Address;
            prop.City=hospitalProp.City;
            prop.Country=hospitalProp.Country;
            prop.Type=hospitalProp.Type;
            prop.PostCode=hospitalProp.PostCode;
            prop.rooms = hospitalProp.rooms;

            _unitOfWork.Save();
        }

    }
}
