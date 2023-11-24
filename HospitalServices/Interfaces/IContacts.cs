using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using ViewModels;

namespace HospitalServices.Interfaces
{
    public interface IContacts
    {
        public void AddContact(ContactViewModel model);
        public void RemoveContact(Guid id);
        public PageUtil<ContactViewModel> GetAllContacts(int pageNumber, int pageSize);
        public ContactViewModel GetContact(Guid id);
        public void UpdateContact(ContactViewModel model);
    }
}
