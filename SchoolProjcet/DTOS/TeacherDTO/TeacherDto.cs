using System.ComponentModel.DataAnnotations;

namespace SchoolProjcet.DTOS.TeacherDTO
{
    public class TeacherDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }


        public string Email { get; set; }


        public string? PhoneNumber { get; set; }

        public decimal Salary { get; set; }
        public string DepartmentName { get; set; }
    }
}
