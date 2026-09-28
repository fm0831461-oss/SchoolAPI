using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Repo.Implement
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<Student> GetAll()
        {
            return _context.Students.Include(e => e.ClassRoom).ToList();
        }
        public Student GetById(int id)
        {
            return _context.Students.Include(e => e.ClassRoom).FirstOrDefault(e => e.Id == id);
        }
        public void Create(Student student)
        {
            _context.Students.Add(student);
           
        }
        public void update(Student student)
        {
            _context.Students.Update(student);
         
        }
        public void delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
               
            }
        }
        public void save()
        {
            _context.SaveChanges();
        }
    }
}
