using Microsoft.EntityFrameworkCore;
using WebApplication_Test_Task_Api_Doctor_Patient.Interfaces;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.DbContextModels;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Models.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private readonly DoctorsAndPatientsDbContext doctorDbContext;

        public DoctorRepository(DoctorsAndPatientsDbContext doctorDbContext)
        {
            this.doctorDbContext = doctorDbContext;
        }

        public async Task<bool> Create(Doctor item)
        {
            doctorDbContext.Doctors.Add(item);
            await doctorDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Doctor> Delete(Guid id)
        {
            var doctor = await Get(id);

            if (doctor != null)
            {
                doctorDbContext.Doctors.Remove(doctor);
                await doctorDbContext.SaveChangesAsync();
            }

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get(int page, int pageSize)
        {
            return await doctorDbContext.Doctors
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(d => d.District)
                .Include(d => d.Specialization)
                .Include(d => d.Cabinet)
                .ToListAsync();
        }

        public async Task<Doctor> Get(Guid id)
        { 
            var doctor = await doctorDbContext.Doctors                
                .Include(d => d.District)
                .Include(d => d.Specialization)
                .Include(d => d.Cabinet)
                .SingleOrDefaultAsync(d => d.Id == id);
            return doctor;
        }

        public async Task<bool> Update(Doctor item)
        {
            Doctor currentDoctor = await Get(item.Id);

            currentDoctor.District = item.District;
            currentDoctor.Cabinet = item.Cabinet;
            currentDoctor.FullName = item.FullName;
            currentDoctor.Specialization = item.Specialization;

            doctorDbContext.Doctors.Update(currentDoctor);
            await doctorDbContext.SaveChangesAsync();
            return true;
        }
    }
}
