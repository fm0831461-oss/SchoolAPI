using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTOS.StudentDto;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly  IStudentRepo repo;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepo repo, IMapper _mapper)
        {
            this.repo = repo;
            this._mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = repo.GetAll();
            var studentDTOs = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = repo.GetById(id);
            if (student == null)
            {
                return NotFound($"Student with id {id} not found.");
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);

            return Ok(studentDTO);
        }


        [HttpPost("create")]
        public IActionResult Create(StudentCreate s)
        {
            if (s == null)
            {
                return BadRequest("Student data cannot be null.");
            }
            var student = _mapper.Map<Student>(s);

            repo.Create(student);
            repo.save();
            return Ok(s);
        }





        [HttpPut("update/{id}")]
        public IActionResult Update(int id, StudentUpdate student)
        {
            if (student == null)
            {
                return BadRequest("Student data cannot be null.");
            }

            var existingStudent = repo.GetById(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with id {id} not found.");
            }

            existingStudent = _mapper.Map(student, existingStudent);

            repo.save();
            return Ok(student);
        }



        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = repo.GetById(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with id {id} not found.");
            }
            var s = _mapper.Map<StudentDTO>(existingStudent);

            repo.delete(id);
            repo.save();
            return Ok(s);
        }
    }
}
//linq methods
//        //1
//        [HttpGet("grade")]
//        public IActionResult GetGrade(int grad ) 
//        {
//            var s = _context.Students .Where(s => s.ClassRoomId == 2 &&s.Enrollments.Any(e => e.Grade >= grad)).ToList();

//            return Ok(s);
//        }

//        //2
//        [HttpGet("First")]
//        public IActionResult GetFirst(int classid)
//        {
//            var s = _context.Students.Where(s => s.ClassRoomId == classid).OrderBy(o => o.Id).FirstOrDefault();

//            return Ok(s);
//        }


//        //3
//        [HttpGet("NotFound")]
//        public IActionResult GetFound(int classId)
//        {
//            var s = _context.Students.Where(s => s.ClassRoomId == classId).FirstOrDefault();
//            if(s == null)
//            {
//                return NotFound($"No students found in class with id {classId}.");
//            }   

//            return Ok(s);
//        }


//        //4
//        [HttpGet("Email")]
//        public IActionResult GetEmail(string Email)
//        {
//            var s = _context.Students.Single(e=>e.Email == Email);

//            return Ok(s);
//        }

//        //5
//        [HttpGet("EmailMatch")]
//        public IActionResult GetEmailMatch(string Email)
//        {
//            var s = _context.Students.SingleOrDefault(e => e.Email == Email);
//            if(s ==null)
//            {
//                return NotFound($"No students found with email {Email}.");
//            }
//            return Ok(s);
//        }


//        //6

//        [HttpGet("last")]
//        public IActionResult GetLast(int studentId)
//        {
//            var enrollment = _context.Enrollments
//                .Where(e => e.StudentId == studentId)
//                .OrderBy(e => e.EnrollmentDate)
//                .LastOrDefault();

//            return Ok(enrollment);
//        }


//        //7

//        [HttpGet("find")]
//        public IActionResult GetFind(int studentId)
//        {
//            var enrollment = _context.Enrollments
//                .Where(e => e.StudentId == studentId)
//                 .OrderBy(e => e.EnrollmentDate)
//                .LastOrDefault();
//            if (enrollment == null)
//            {
//                return NotFound($"No enrollment found for student with id {studentId}.");
//            }
//            return Ok(enrollment);
//        }


//        //8
//        [HttpGet("at/{index}")]
//        public IActionResult GetAt(int index)
//        {
//            var student = _context.Students
//                .OrderBy(s => s.Id)
//                .ElementAt(index);

//            return Ok(student);
//        }

//        //11     dont solve
//        //12
//        [HttpGet("class")]
//        public IActionResult GetClass(int ClassId)
//        {
//            var c = _context.Students.Where(c => c.ClassRoomId == ClassId).Select(e => new {
//                e.Id,
//                FullName = e.FirstName + " " + e.LastName
//            });
//            return Ok(c);
//        }
//        //13
//        [HttpGet("classa")]
//        public IActionResult GetClassa(int ClassId)
//        {
//            var c = _context.Students.Where(c => c.ClassRoomId == ClassId).Select(e => new {
//                e.Id,
//                FullName = e.FirstName + " " + e.LastName,
//                e.Email
//            });
//            return Ok(c);
//        }

//        //15
//        [HttpGet("/all-subjects")]
//        public IActionResult GetAllSubjects()
//        {
//            var subjects = _context.Students.OrderBy(e=>e.LastName).ToList();


//            return Ok(subjects);
//        }





//        //17
//        [HttpGet("order-by-classroom")]
//        public IActionResult OrderByClassRoom()
//        {
//            var subjects = _context.Students.OrderBy(e => e.ClassRoomId).ThenBy(e=>e.LastName).ToList();

//            return Ok(subjects);
//        }
//        [HttpGet("count")]
//        public IActionResult GetCount(int classId)
//        {
//            var count = _context.Students.Where(s => s.ClassRoomId == classId).Count();
//            return Ok(count);
//        }
//    }

//}
