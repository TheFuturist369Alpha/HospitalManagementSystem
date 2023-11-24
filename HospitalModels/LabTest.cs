using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public enum TestResult
    {
        Positive,Negative
    }
    public class LabTest
    {
        public Guid Id { get; set; }
        public AppUser Patient { set; get; }
        public AppUser Specialist { set; get; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int LabNumber { get; set; }
        public string TestType {get; set; }
        public int BloodPressure { get; set; }
        public int Temperature { get; set; }  
        public decimal LabCharge { get; set; }
        public TestResult result { get;set; }


    }
}
