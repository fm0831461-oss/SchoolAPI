using AutoMapper;
using School.Models;
using SchoolProjcet.DTOS.EnrollmentDTO;
using SchoolProjcet.DTOS.StudentDto;
namespace SchoolProjcet.Mapping
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentCreate>().ReverseMap();
            CreateMap<Enrollment, EnrollmentUpdate>().ReverseMap();
        }
    }
}
