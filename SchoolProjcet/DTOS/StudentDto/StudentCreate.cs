namespace SchoolProjcet.DTOS.StudentDto
{
    public class StudentCreate
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
