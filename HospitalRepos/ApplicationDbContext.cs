using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using HospitalModels;

namespace HospitalRepos
{
    public class ApplicationDbContext:IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Department> Depts { get; set; }
        public DbSet<HospitalProp> Hospitals { get; set; }
        public DbSet<LabTest> Lab_Tests { get; set; }
        public DbSet<MedicineInfo> Medicines { get; set; }
        public DbSet<MedicineSupplier> Suppliers { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<PayRoll> Payrolls { get; set; }
        public DbSet<PrescribedMedicine> PrescribedDrugs { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}