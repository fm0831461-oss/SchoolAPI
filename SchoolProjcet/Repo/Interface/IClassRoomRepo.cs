using School.Models;

namespace SchoolProjcet.Repo.Interface
{
    public interface IClassRoomRepo
    {
        List<ClassRoom> GetAll();
        ClassRoom GetById(int id);
        void Create(ClassRoom classRoom);
        void update(ClassRoom classRoom);
        void delete(int id);
        void save();
    }
}
