using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Repo.Implement
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly AppDbContext _context;
        public TeacherRepo(AppDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Teacher teacher)
        {
           _context.Teachers.Add(teacher);
        }

        public void delete(int id)
        {
            var d = _context.Teachers.Find(id);
            if (d != null)
            {
                _context.Teachers.Remove(d);
            }
        }

        public List<Teacher> GetAll()
        {
          var teachers =  _context.Teachers.Include(t => t.Department).ToList();
          return teachers;
        }

        public Teacher GetById(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public void update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
        }
    }
}
