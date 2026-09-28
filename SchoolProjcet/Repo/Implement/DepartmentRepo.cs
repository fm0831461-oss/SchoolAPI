using School.AppContext;
using School.Models;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Repo.Implement
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext _context;
        public DepartmentRepo(AppDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Department department)
        {
            _context.Departments.Add(department);
        }

        public void delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
            }
        }

        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public void save()
        {
            _context.SaveChanges();
        }
        

        public void update(Department department)
        {
            _context.Departments.Update(department);
        }
    }
}
