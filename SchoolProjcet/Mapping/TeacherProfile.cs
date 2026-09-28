using AutoMapper;
using School.Models;
using SchoolProjcet.DTOS.TeacherDTO;

namespace SchoolProjcet.Mapping
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department.Name)).ReverseMap();

            CreateMap<TeacherCreate, Teacher>().ReverseMap();

            CreateMap<TeacherUpdate, Teacher>().ReverseMap();
        }
    }
}