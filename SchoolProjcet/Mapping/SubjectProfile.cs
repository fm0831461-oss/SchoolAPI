using AutoMapper;
using School.Models;
using SchoolProjcet.DTOS.StudentDto;
using SchoolProjcet.DTOS.SubDto;
namespace SchoolProjcet.Mapping
{
    public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
      
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, SubjectCreate>().ReverseMap();
            CreateMap<Subject, SubjectUpdate>().ReverseMap();
        }
    }
    }

