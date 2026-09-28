using School.Models;

namespace SchoolProjcet.Repo.Interface
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Create(Department department);
        void update(Department department);
        void delete(int id);
        void save();
    }
}
