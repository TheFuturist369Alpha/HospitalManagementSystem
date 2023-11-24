using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class MedicineInfo
    {
        public Guid Id { get; set; }
        public string NameOfProduct { get; set; }
        public string Description { get; set; }
        public MedicineSupplier supplier { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
