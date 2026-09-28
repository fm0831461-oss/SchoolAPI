using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Repo.Implement
{
    public class EnrollmentRepo : IEnrollmentRepo
    {
        private readonly AppDbContext _context;
        public EnrollmentRepo(AppDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
        }

        public void delete(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }

        }

        public List<Enrollment> GetAll()
        {
           var enrollments = _context.Enrollments.Include(t => t.Student).Include(r => r.Subject).ToList();
           return enrollments;
        }

        public Enrollment GetById(int id)
        {
            return _context.Enrollments.Find(id);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public void update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
        }
    }
}
