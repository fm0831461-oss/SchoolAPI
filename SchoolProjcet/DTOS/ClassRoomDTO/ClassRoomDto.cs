using System.ComponentModel.DataAnnotations;

namespace SchoolProjcet.DTOS.ClassRoomDTO
{
    public class ClassRoomDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GradeLevel { get; set; }

        public int Capacity { get; set; }
    }
}
