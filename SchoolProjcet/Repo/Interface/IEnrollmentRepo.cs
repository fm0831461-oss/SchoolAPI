using School.Models;

namespace SchoolProjcet.Repo.Interface
{
    public interface IEnrollmentRepo
    {
        List<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Create(Enrollment enrollment);
        void update(Enrollment enrollment);
        void delete(int id);
        void save();
    }
}
