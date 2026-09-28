using School.AppContext;
using School.Models;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Repo.Implement
{
    public class SubjectRepo : ISubjectRepo
    {
        private readonly AppDbContext _context;
        public SubjectRepo(AppDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Subject subject)
        {
            _context.Subjects.Add(subject);
        }

        public void delete(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
            }
        }

        public List<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetById(int id)
        {
            return _context.Subjects.Find(id);
        }

        public void save()
        {
            _context.SaveChanges();
        }
        

        public void update(Subject subject)
        {
            _context.Subjects.Update(subject);
        }
    }
}
