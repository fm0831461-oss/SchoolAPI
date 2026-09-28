namespace SchoolProjcet.DTOS.SubDto
{
    public class SubjectCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MaxGrade { get; set; }
    }
}
