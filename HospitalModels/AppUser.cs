using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace HospitalModels
{
    public enum Gender
    {
        Male,Female,NonBinary,Other
    }

    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public Gender gender { get; set; }
        public string Address { get; set; }
        public string Specialist { get; set; }
        public Department department { get; set; }
        public IEnumerable<Appointment> appointments { get; set; }
        public IEnumerable<PayRoll> payRolls { get; set; }
        
    }
}