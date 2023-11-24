using HospitalModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }

        public ContactViewModel(Contacts contacts)
        {
            Id = contacts.Id;
            Email=contacts.Email;
            phone = contacts.phone;
            Address = contacts.Address;

            
        }
        public ContactViewModel()
        {

        }

        public Contacts ToContact()
        {
            return new Contacts()
            {
                Id=Id,
                Email=Email,
                phone=phone,
                Address=Address
               
            };
        }
    }
}
