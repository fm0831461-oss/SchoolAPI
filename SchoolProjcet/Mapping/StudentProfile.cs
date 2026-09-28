using AutoMapper;
using School.Models;
using SchoolProjcet.DTOS.StudentDto;
namespace SchoolProjcet.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, StudentCreate>().ReverseMap();
            CreateMap<Student, StudentUpdate>().ReverseMap();
        }
       
    }
}
