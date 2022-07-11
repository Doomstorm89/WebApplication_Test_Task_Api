using WebApplication_Test_Task_Api_Doctor_Patient.Models;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.Mockups;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Helpers
{
    public class PatientHelper
    {
        public Patient CreatePatientFromMock(PatientValuesMock patientMock)
        {
            if (patientMock == null)
            {
                return null;
            }

            var patient = new Patient();

            patient.Id = patientMock.Id;

            patient.Name = patientMock.Name;
            patient.Surname = patientMock.Surname;
            patient.MiddleName = patientMock.MiddleName;

            patient.BirthDate = patientMock.BirthDate;

            patient.Gender = patientMock.Gender;

            patient.Address = patientMock.Address;            

            var district = new District();
            district.Number = patientMock.DistrictNumber;            

            patient.District = district;

            return patient;
        }

        public PatientIdsMock GetMockWithIdsFromPatient(Patient patient)
        {
            return new PatientIdsMock()
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                MiddleName = patient.MiddleName,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                Address = patient.Address,
                DistrictId = patient.District.Id,
            };
        }

        public PatientValuesMock GetMockWithValuesFromPatient(Patient patient)
        {
            return new PatientValuesMock()
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                MiddleName = patient.MiddleName,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                Address = patient.Address,
                DistrictNumber = patient.District.Number,
            };
        }
    }
}
