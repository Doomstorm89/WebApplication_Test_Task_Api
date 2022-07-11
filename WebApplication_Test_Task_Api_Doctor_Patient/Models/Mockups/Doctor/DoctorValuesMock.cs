
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Models.Mockups
{
    public class DoctorValuesMock
    {       
        [FromQuery]
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public int CabinetNumber { get; set; }
        public string? SpecializationName { get; set; }
        public int DistrictNumber { get; set; }        
    }
}
