namespace HospitalModels
{
    public class Bill
    {
        public Guid Id { get; set; }
        public decimal PresonnelCharge { get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal LabCharge { get; set; }
        public decimal NurseCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public AppUser patient { get; set; }    
        public int NoOfDays { get; set; }
        public decimal Total { get; set; }
    }
}