using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class PatientReport
    {
        public Guid Id { get; set; }
        public string Diagnosis { set; get; }
        public string MoreDiagnosisInfo { get; set; }
        public AppUser Patient { get; set; }
        public AppUser Specialist{ get; set; }
        public PrescribedMedicine Medicine { set; get; }
        public Bill bill { get; set; }
    }
}
