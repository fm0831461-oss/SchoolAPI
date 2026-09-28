using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTOS.TeacherDTO;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo.Interface;
namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepo Repo;
        private readonly IMapper _mapper;
        public TeacherController(ITeacherRepo Repo, IMapper _mapper)
        {
            //_context = new AppDbContext();
            //_mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClassRoomProfile>()).CreateMapper();
            this.Repo = Repo;
            this._mapper = _mapper;
        }

        //function write using DTOs

        [HttpGet]
        public IActionResult GetTeachers()
        {

            List<Teacher> dept = Repo.GetAll();

            List<TeacherDto> departmentDTOs = new List<TeacherDto>();

            foreach (var d in dept)
            {
                var ddto = new TeacherDto
                {
                    Id = d.Id,
                    FullName = d.FirstName + " " + d.LastName,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    Salary = d.Salary,
                    DepartmentName = d.Department.Name
                };
                departmentDTOs.Add(ddto);
            }
            if (dept == null || dept.Count == 0)
            {
                return NotFound("No Teacher found.");
            }
            return Ok(departmentDTOs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dept = Repo.GetById(id);

            var dep = new TeacherDto
            {
                Id = dept.Id,
                FullName = dept.FirstName + " " + dept.LastName,
                Email = dept.Email,
                PhoneNumber = dept.PhoneNumber,
                Salary = dept.Salary,
                DepartmentName = dept.Department.Name
            };
            return Ok(dep);
        }
        [HttpPost]
        public IActionResult CreateTeacher(TeacherCreate createTeacherDTO)
        {
            if (createTeacherDTO == null)
            {
                return BadRequest("Teacher cannot be null.");


            }
            var teacher = new Teacher
            {
                FirstName = createTeacherDTO.FirstName,
                LastName = createTeacherDTO.LastName,
                Email = createTeacherDTO.Email,
                PhoneNumber = createTeacherDTO.PhoneNumber,
                Salary = createTeacherDTO.Salary,
                DepartmentId = createTeacherDTO.DepartmentId
            };
           Repo.Create(teacher);
            Repo.save();
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }
        [HttpPut]
        public IActionResult UpdateTeacher(TeacherUpdate updateTeacherDTO, int id)
        {
            if (updateTeacherDTO == null)
            {
                return BadRequest("Teacher cannot be null.");
            }


            var dept = Repo.GetById(id);
            if (dept == null)
            {
                return NotFound("Teacher not found.");
            }

            dept.FirstName = updateTeacherDTO.FirstName;
            dept.LastName = updateTeacherDTO.LastName;
            dept.Email = updateTeacherDTO.Email;
            dept.PhoneNumber = updateTeacherDTO.PhoneNumber;
            dept.Salary = updateTeacherDTO.Salary;
            dept.DepartmentId = updateTeacherDTO.DepartmentId;
            Repo.update(dept);
            Repo.save();
            return NoContent();
        }
        [HttpPatch]
        public IActionResult UpdateName(int id, string name)
        {
            var dept = Repo.GetById(id);
            if (dept == null)
            {
                return NotFound("Teacher not found.");
            }

            dept.FirstName = name;
            Repo.save();
            return NoContent();
        }
        ////////////////////////////////////////////////
        //[HttpGet]
        //public IActionResult GetTeachers()
        //{
        //    var teachers = _context.Teachers.Include(t => t.Department).ToList();

        //    if (teachers.Count == 0)
        //    {
        //        return NotFound("No Teacher found.");
        //    }

        //    var teacherDTOs = _mapper.Map<List<TeacherDto>>(teachers);

        //    return Ok(teacherDTOs);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var teacher = _context.Teachers
        //        .Include(t => t.Department)
        //        .FirstOrDefault(t => t.Id == id);

        //    if (teacher == null)
        //    {
        //        return NotFound("Teacher not found.");
        //    }

        //    var teacherDTO = _mapper.Map<TeacherDto>(teacher);

        //    return Ok(teacherDTO);
        //}

        //[HttpPost]
        //public IActionResult CreateTeacher(TeacherCreate createTeacherDTO)
        //{
        //    if (createTeacherDTO == null)
        //    {
        //        return BadRequest("Teacher cannot be null.");
        //    }

        //    var teacher = _mapper.Map<Teacher>(createTeacherDTO);

        //    _context.Teachers.Add(teacher);
        //    _context.SaveChanges();

        //    return CreatedAtAction(
        //        nameof(GetById),
        //        new { id = teacher.Id },
        //        teacher
        //    );
        //}

        //[HttpPut]
        //public IActionResult UpdateTeacher(TeacherUpdate updateTeacherDTO, int id)
        //{
        //    if (updateTeacherDTO == null)
        //    {
        //        return BadRequest("Teacher cannot be null.");
        //    }

        //    var teacher = _context.Teachers.Find(id);

        //    if (teacher == null)
        //    {
        //        return NotFound("Teacher not found.");
        //    }

        //    _mapper.Map(updateTeacherDTO, teacher);

        //    _context.SaveChanges();

        //    return NoContent();
        //}

        //[HttpPatch]
        //public IActionResult UpdateName(int id, string name)
        //{
        //    var dept = _context.Teachers.Find(id);
        //    if (dept == null)
        //    {
        //        return NotFound("Teacher not found.");
        //    }

        //    dept.FirstName = name;
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
