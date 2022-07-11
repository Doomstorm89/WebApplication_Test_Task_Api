using Microsoft.AspNetCore.Mvc;
using WebApplication_Test_Task_Api_Doctor_Patient.Helpers;
using WebApplication_Test_Task_Api_Doctor_Patient.Interfaces;
using WebApplication_Test_Task_Api_Doctor_Patient.Models;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.Mockups;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private const string GetAllPatients = "GetAllPatients";
        private const string GetPatient = "GetPatient";

        private const int PageSize = 5;
        private const int Page = 1;

        private readonly IRepository<Patient> repository;
        private readonly PatientHelper patientHelper;

        public PatientController(IRepository<Patient> repository)
        {
            this.repository = repository;
            patientHelper = new PatientHelper();
        }

        [HttpGet("{sortBy}/{page}", Name = GetAllPatients)]
        public async Task<IEnumerable<PatientValuesMock>> Get(string sortBy, int page = Page)
        {
            var patientsWithValues = new List<PatientValuesMock>();
            foreach (var patient in await repository.Get(page, PageSize))
            {
                var p = patientHelper.GetMockWithValuesFromPatient(patient);
                patientsWithValues.Add(p);
            }

            Func<PatientValuesMock, object> column = c => {
                switch (sortBy.ToLower())
                {
                    case "name": return c.Name;
                    case "surname": return c.Surname;
                    case "middlename": return c.MiddleName;
                    case "address": return c.Address;
                    case "gender": return c.Gender;
                    case "birthdate": return c.BirthDate;
                    case "districtnumber": return c.DistrictNumber;
                    default: return c.Id;
                }
            };

            return patientsWithValues.OrderBy(column);
        }

        [HttpGet("{id}", Name = GetPatient)]
        public async Task<IActionResult> Get(Guid id)
        {
            Patient patient = await repository.Get(id);

            if (patient == null)
            {
                return NotFound();
            }

            var patientWithIds = patientHelper.GetMockWithIdsFromPatient(patient);

            return new ObjectResult(patientWithIds);
        }

        [HttpPost]
        public async Task<ActionResult<PatientValuesMock>> Create([FromBody] PatientValuesMock patientMock)
        {
            if (patientMock == null)
            {
                return BadRequest();
            }

            try
            {
                var patient = patientHelper.CreatePatientFromMock(patientMock);

                await repository.Create(patient);

                var patientWithIds = patientHelper.GetMockWithIdsFromPatient(patient);

                return CreatedAtRoute(GetPatient, new { id = patient.Id }, patientWithIds);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] PatientValuesMock patientMock)
        {
            if (patientMock == null)
            {
                return BadRequest();
            }

            var updatePatient = await repository.Get(Id);
            if (updatePatient == null)
            {
                return NotFound();
            }

            patientMock.Id = Id;
            var patient = patientHelper.CreatePatientFromMock(patientMock);

            await repository.Update(patient);
            return new ObjectResult(patientMock);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var patient = await repository.Delete(Id);

            if (patient == null)
            {
                return BadRequest();
            }

            var patientWithIds = patientHelper.GetMockWithIdsFromPatient(patient);

            return new ObjectResult(patientWithIds);
        }
    }
}
