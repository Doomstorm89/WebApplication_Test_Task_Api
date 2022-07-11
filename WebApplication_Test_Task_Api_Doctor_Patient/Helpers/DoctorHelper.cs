using WebApplication_Test_Task_Api_Doctor_Patient.Models;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.Mockups;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Helpers
{
    public class DoctorHelper
    {               
        public Doctor CreateDoctorFromMock(DoctorValuesMock doctorSingleMock)
        {
            if (doctorSingleMock == null)
            {
                return null;
            }

            var doctor = new Doctor();

            doctor.Id = doctorSingleMock.Id;

            doctor.FullName = doctorSingleMock.FullName;

            var cabinet = new Cabinet();
            cabinet.Number = doctorSingleMock.CabinetNumber;

            var district = new District();
            district.Number = doctorSingleMock.DistrictNumber;

            var specialization = new Specialization();
            specialization.Name = doctorSingleMock.SpecializationName;

            doctor.Cabinet = cabinet;
            doctor.District = district;
            doctor.Specialization = specialization;

            return doctor;
        }

        public DoctorIdsMock GetMockWithIdsFromDoctor(Doctor doctor)
        {
            return new DoctorIdsMock()
            {
                Id = doctor.Id,
                FullName = doctor.FullName,                
                CabinetId = doctor.Cabinet.Id,
                SpecializationId = doctor.Specialization.Id,
                DistrictId = doctor.District.Id,
            };
        }

        public DoctorValuesMock GetMockWithValuesFromDoctor(Doctor doctor)
        {
            return new DoctorValuesMock()
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                CabinetNumber = doctor.Cabinet.Number,
                DistrictNumber = doctor.District.Number,
                SpecializationName = doctor.Specialization.Name
            };
        }
    }
}
