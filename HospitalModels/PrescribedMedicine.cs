using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class PrescribedMedicine
    {
        public Guid Id { get; set; }
        public IEnumerable<MedicineInfo> Medicines { get; set; }

    }
}
