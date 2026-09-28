using School.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolProjcet.DTOS.EnrollmentDTO
{
    public class EnrollmentDto
    {
        public int Id { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal Grade { get; set; }
    }
}
