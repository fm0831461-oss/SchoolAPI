using AutoMapper;
using School.Models;
using SchoolProjcet.DTOS.ClassRoomDTO;
namespace SchoolProjcet.Mapping
{
    public class ClassRoomProfile:Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<ClassRoom, ClassRoomDto>().ReverseMap();
            CreateMap<ClassRoom, ClassRoomCreate>().ReverseMap();
            CreateMap<ClassRoom, ClassRoomUpdate>().ReverseMap();
        }
    }
}
