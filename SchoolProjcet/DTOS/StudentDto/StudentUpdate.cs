namespace SchoolProjcet.DTOS.StudentDto
{
    public class StudentUpdate
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
