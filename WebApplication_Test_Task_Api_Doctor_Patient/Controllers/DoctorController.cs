using Microsoft.AspNetCore.Mvc;
using WebApplication_Test_Task_Api_Doctor_Patient.Helpers;
using WebApplication_Test_Task_Api_Doctor_Patient.Interfaces;
using WebApplication_Test_Task_Api_Doctor_Patient.Models;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.Mockups;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private const string GetAllDoctors = "GetAllDoctors";
        private const string GetDoctor = "GetDoctor";

        private const int PageSize = 5;
        private const int Page = 1;

        private readonly IRepository<Doctor> repository;
        private readonly DoctorHelper doctorHelper;

        public DoctorController(IRepository<Doctor> repository)
        {
            this.repository = repository;
            doctorHelper = new DoctorHelper();
        }

        [HttpGet("{sortBy}/{page}", Name = GetAllDoctors)]
        public async Task<IEnumerable<DoctorValuesMock>> Get(string sortBy, int page = Page)
        {
            var doctorsWithValues = new List<DoctorValuesMock>();
            foreach (var doctor in await repository.Get(page, PageSize))
            {
                var d = doctorHelper.GetMockWithValuesFromDoctor(doctor);
                doctorsWithValues.Add(d);
            }

            Func<DoctorValuesMock, object> column = c => {
                switch (sortBy.ToLower())
                {
                    case "cabinetnumber": return c.CabinetNumber;
                    case "districtnumber": return c.DistrictNumber;
                    case "specializationname": return c.SpecializationName;
                    case "fullname": return c.FullName;
                    default: return c.Id;
                }
            };

            return doctorsWithValues.OrderBy(column);
        }

        [HttpGet("{id}", Name = GetDoctor)]
        public async Task<IActionResult> Get(Guid id)
        {
            Doctor doctor = await repository.Get(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var doctorWithIds = doctorHelper.GetMockWithIdsFromDoctor(doctor);

            return new ObjectResult(doctorWithIds);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorValuesMock>> Create([FromBody] DoctorValuesMock doctorSingleMock)
        {
            if (doctorSingleMock == null)
            {
                return BadRequest();
            }

            try
            {
                var doctor = doctorHelper.CreateDoctorFromMock(doctorSingleMock);

                await repository.Create(doctor);

                var doctorWithIds = doctorHelper.GetMockWithIdsFromDoctor(doctor);

                return CreatedAtRoute(GetDoctor, new { id = doctor.Id }, doctorWithIds);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] DoctorValuesMock doctorSingleMock)
        {
            if (doctorSingleMock == null)
            {
                return BadRequest();
            }

            var updateDoctor = await repository.Get(Id);
            if (updateDoctor == null)
            {
                return NotFound();
            }

            doctorSingleMock.Id = Id;
            var doctor = doctorHelper.CreateDoctorFromMock(doctorSingleMock);

            await repository.Update(doctor);
            return new ObjectResult(doctorSingleMock);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var doctor = await repository.Delete(Id);

            if (doctor == null)
            {
                return BadRequest();
            }

            var doctorWithIds = doctorHelper.GetMockWithIdsFromDoctor(doctor);

            return new ObjectResult(doctorWithIds);
        }
    }
}
