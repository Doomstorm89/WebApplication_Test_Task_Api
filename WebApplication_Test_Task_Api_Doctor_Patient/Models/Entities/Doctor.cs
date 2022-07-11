namespace WebApplication_Test_Task_Api_Doctor_Patient.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public virtual Cabinet Cabinet { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual District District { get; set; }
    }
}
