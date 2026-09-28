using School.AppContext;
using School.Models;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Repo.Implement
{
    public class ClassRoomRepo : IClassRoomRepo
    {
        private readonly AppDbContext _context;
        public ClassRoomRepo(AppDbContext _context)
        {
            this._context = _context;
        }
        public void Create(ClassRoom classRoom)
        {
            _context.ClassRooms.Add(classRoom);
        }

        public void delete(int id)
        {
            var classRoom = _context.ClassRooms.Find(id);
            if (classRoom != null)
            {
                _context.ClassRooms.Remove(classRoom);
            }
        }

        public List<ClassRoom> GetAll()
        {
            return _context.ClassRooms.ToList();
        }

        public ClassRoom GetById(int id)
        {
            return _context.ClassRooms.Find(id);
        }
        

        public void save()
        {
            _context.SaveChanges();
        }

        public void update(ClassRoom classRoom)
        {
            _context.ClassRooms.Update(classRoom);
        }
    }
}
