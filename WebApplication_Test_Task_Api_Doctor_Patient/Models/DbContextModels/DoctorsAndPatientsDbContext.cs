using Microsoft.EntityFrameworkCore;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Models.DbContextModels
{
    public class DoctorsAndPatientsDbContext : DbContext
    {
        public DoctorsAndPatientsDbContext(DbContextOptions<DoctorsAndPatientsDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Cabinet> Cabinets { get; set; } = null!;
        public DbSet<District> Districts { get; set; } = null!;
        public DbSet<Specialization> Specializations { get; set; } = null!;
    }
}
