using HospitalModels;
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
    public class ContactService:IContacts 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public void AddContact(ContactViewModel model)
        {
            _unitOfWork.GenericRepo<Contacts>().Add(model.ToContact());
            _unitOfWork.Save();
        }

        public PageUtil<ContactViewModel> GetAllContacts(int pageNumber, int pageSize)
        {
            ContactViewModel hvm = new ContactViewModel();
            int count;
            List<ContactViewModel> viewList = new List<ContactViewModel>();
            try
            {
                int ExcludedRecords = pageNumber * pageSize - pageSize;
                var models = _unitOfWork.GenericRepo<Contacts>().GetAll()
                    .Skip(ExcludedRecords).Take(pageSize).ToList();
                count = _unitOfWork.GenericRepo<Contacts>().GetAll().ToList().Count;
                viewList = ToHospitalVMList(models);
            }
            catch (Exception ex)
            {
                throw;
            }

            return new PageUtil<ContactViewModel>()
            {
                Data = viewList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageCount = count


            };

        }

        private List<ContactViewModel> ToHospitalVMList(List<Contacts> contacts)
        {

            return contacts.Select(x => new ContactViewModel(x)).ToList();

        }

        public ContactViewModel GetContact(Guid id)
        {
            Contacts contact = _unitOfWork.GenericRepo<Contacts>().GetById(x => x.Id == id);
            return new ContactViewModel(contact);
        }

        public void RemoveContact(Guid id)
        {
            _unitOfWork.GenericRepo<Contacts>().Remove(x => x.Id == id);
            _unitOfWork.Save();
        }

        public void UpdateContact(ContactViewModel contact)
        {
            Contacts hld = _unitOfWork.GenericRepo<Contacts>().Update(x => x.Id == contact.Id);
           hld.phone = contact.phone;
            hld.Address = contact.Address;
            hld.Id = contact.Id;
            hld.Email = contact.Email;

            _unitOfWork.Save();
        }
    }
}
