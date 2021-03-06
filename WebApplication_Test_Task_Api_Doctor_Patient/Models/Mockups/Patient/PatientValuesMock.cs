using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Test_Task_Api_Doctor_Patient.Models.Mockups
{
    public class PatientValuesMock
    {
        [FromQuery]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public int DistrictNumber { get; set; }
    }
}
