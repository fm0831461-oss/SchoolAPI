using School.Models;

namespace SchoolProjcet.Repo.Interface
{
    public interface ITeacherRepo
    {
        List<Teacher> GetAll();
        Teacher GetById(int id);
        void Create(Teacher teacher);
        void update(Teacher teacher);
        void delete(int id);
        void save();
    }
}
