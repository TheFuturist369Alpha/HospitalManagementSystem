using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalModels
{
   
    public class HospitalProp
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumFloors { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public IEnumerable<Room> rooms { get; set; }
        public IEnumerable<Room> contacts { get; set; }

       
    }
}
