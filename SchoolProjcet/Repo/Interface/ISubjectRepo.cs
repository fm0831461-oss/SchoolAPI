using School.Models;

namespace SchoolProjcet.Repo.Interface
{
    public interface ISubjectRepo
    {
        List<Subject> GetAll();
        Subject GetById(int id);
        void Create(Subject subject);
        void update(Subject subject);
        void delete(int id);
        void save();
    }
}
