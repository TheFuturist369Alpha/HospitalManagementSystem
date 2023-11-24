
using HospitalModels;
namespace ViewModels
{
    public enum HospitalType
    {
        Private, Public
    }
    public class HospitalViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HospitalType? Type { get; set; } = null;
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public HospitalViewModel()
        {

        }
        public HospitalViewModel(HospitalProp hospital)
        {
            Id=hospital.Id;
            Name = hospital.Name;
            Type = (HospitalType)Enum.Parse(typeof(HospitalType),hospital.Type);
            Address = hospital.Address;
            PostCode = hospital.PostCode;
            Country = hospital.Country;
            City = hospital.City;

        }

        public HospitalProp ToHospitalProp()
        {
            return new HospitalProp()
            {
                Name = Name,
                Type = Type.ToString(),
                Address = Address,
                PostCode = PostCode,
                Country = Country,
                City = City

            };

        }
    }

    public static class HospitalPropExtension
    {
        public static HospitalViewModel ToViewModel(this HospitalProp hospitalProp)
        {
            return new HospitalViewModel()
            {
                Id = hospitalProp.Id,
                Name = hospitalProp.Name,
                Type = (HospitalType)Enum.Parse(typeof(HospitalType), hospitalProp.Type),
                Address = hospitalProp.Address,
                PostCode = hospitalProp.PostCode,
                Country = hospitalProp.Country,
                City = hospitalProp.City

            };
        }
    }
}