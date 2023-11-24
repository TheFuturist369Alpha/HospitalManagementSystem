namespace HospitalModels
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public AppUser Specialist { get; set; }
    }
}