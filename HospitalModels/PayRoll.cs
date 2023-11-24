namespace HospitalModels
{
    public class PayRoll
    {
        public Guid Id { get; set; }
        public AppUser User { get; set; }
        public decimal Annual_Salary { get; set; }
        public decimal Hourly_Salary { get; set; }
        public decimal Bonus_Salary { get; set; }
        public string AccountNumber { get; set; }
    }
}