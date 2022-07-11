using Microsoft.EntityFrameworkCore;
using WebApplication_Test_Task_Api_Doctor_Patient.Interfaces;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.DbContextModels;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Models.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly DoctorsAndPatientsDbContext patientDbContext;

        public PatientRepository(DoctorsAndPatientsDbContext patientDbContext)
        {
            this.patientDbContext = patientDbContext;
        }

        public async Task<bool> Create(Patient item)
        {
            patientDbContext.Patients.Add(item);
            await patientDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Patient> Delete(Guid id)
        {
            Patient patient = await Get(id);

            if (patient != null)
            {
                patientDbContext.Patients.Remove(patient);
                await patientDbContext.SaveChangesAsync();
            }

            return patient;
        }

        public async Task<IEnumerable<Patient>> Get(int page, int pageSize)
        {
            return await patientDbContext.Patients
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(d => d.District)
                .ToListAsync();
        }

        public async Task<Patient> Get(Guid id)
        {
            return await patientDbContext.Patients
                .Include(d => d.District)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Update(Patient item)
        {
            Patient currentPatient = await Get(item.Id);

            currentPatient.BirthDate = item.BirthDate;
            currentPatient.District = item.District;
            currentPatient.Gender = item.Gender;
            currentPatient.Name = item.Name;
            currentPatient.Surname = item.Surname;
            currentPatient.MiddleName = item.MiddleName;
            currentPatient.Address = item.Address;

            patientDbContext.Patients.Update(currentPatient);
            await patientDbContext.SaveChangesAsync();
            return true;
        }
    }
}
