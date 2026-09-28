using AutoMapper;
using School.Models;
using SchoolProjcet.DTOS.DeptDto;
namespace SchoolProjcet.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentCreate>().ReverseMap();
            CreateMap<DepartmentUpdate, Department>().ReverseMap();
        }
    }
}
