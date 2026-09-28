using School.Models;

namespace SchoolProjcet.Repo.Interface
{
    public interface IStudentRepo
    {
        List<Student>GetAll();
        Student GetById(int id);
        void Create(Student student);
        void update(Student student);
        void delete(int id);
        void save();

    }
}
