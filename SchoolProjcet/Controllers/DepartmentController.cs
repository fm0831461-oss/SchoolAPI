using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTOS.DeptDto;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo Repo;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepo Repo, IMapper _mapper)
        {
            //_context = new AppDbContext();
            //_mapper = new MapperConfiguration(cfg => cfg.AddProfile<DepartmentProfile>()).CreateMapper();
            this.Repo = Repo;
            this._mapper = _mapper;
        }

        //function write using DTOs

        [HttpGet]
        public IActionResult GetDepartemnts()
        {

            List<Department> dept = Repo.GetAll();

            List<DepartmentDto> departmentDTOs = new List<DepartmentDto>();

            foreach (var d in dept)
            {
                var ddto = new DepartmentDto
                {
                    ID = d.Id,
                    Name = d.Name,
                    Description = d.Description
                };
                departmentDTOs.Add(ddto);
            }
            if (dept == null || dept.Count == 0)
            {
                return NotFound("No departments found.");
            }
            return Ok(departmentDTOs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dept = Repo.GetById(id);
            if (dept == null)
            {
                return NotFound("Department not found.");
            }
            var dep = new DepartmentDto
            {
                ID = dept.Id,
                Name = dept.Name,
                Description = dept.Description
            };
            return Ok(dep);
        }
        [HttpPost]
        public IActionResult CreateDepartment(DepartmentCreate createDepartmentDTO)
        {
            if (createDepartmentDTO == null)
            {
                return BadRequest("Department cannot be null.");


            }
            var department = new Department
            {
                Name = createDepartmentDTO.Name,
                Description = createDepartmentDTO.Description
            };
            Repo.Create(department);
            Repo.save();
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }
        [HttpPut]
        public IActionResult UpdateDepartment(DepartmentUpdate updateDepartmentDTO, int id)
        {
            if (updateDepartmentDTO == null)
            {
                return BadRequest("Department cannot be null.");
            }


            var dept = Repo.GetById(id);
            if (dept == null)
            {
                return NotFound("DEp not ");
            }

            dept.Name = updateDepartmentDTO.Name;
            dept.Description = updateDepartmentDTO.Description;
            return NoContent();
        }


        [HttpPatch]
        public IActionResult UpdateName(int id, string name)
        {

            var dept = Repo.GetById(id);
            if (dept == null)
            {
                return NotFound("DEp not ");
            }

            dept.Name = name;
            Repo.update(dept);
            Repo.save();
            return NoContent();
        }


        /////////////////////////////////////////
        //[HttpGet]
        //public IActionResult GetDepartemnts()
        //{

        //    List<Department> dept = _context.Departments.Include(t => t.Teachers).ToList();
        //    List<DepartmentDto> departmentDTOs = _mapper.Map<List<DepartmentDto>>(dept);
        //    if (dept == null || dept.Count == 0)
        //    {
        //        return NotFound("No departments found.");
        //    }
        //    return Ok(departmentDTOs);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var dept = _context.Departments
        //        .FirstOrDefault(a => a.Id == id);
        //    var dep = _mapper.Map<DepartmentDto>(dept);
        //    return Ok(dep);
        //}


        //[HttpPost]
        //public IActionResult CreateDepartment(DepartmentCreate createDepartmentDTO)
        //{
        //    if (createDepartmentDTO == null)
        //    {
        //        return BadRequest("Department cannot be null.");


        //    }
        //    var dep = _mapper.Map<Department>(createDepartmentDTO);
        //    _context.Departments.Add(dep);
        //    _context.SaveChanges();
        //    return CreatedAtAction(nameof(GetById), new { id = dep.Id }, dep);
        //}




        //[HttpPut]
        //public IActionResult UpdateDepartment(DepartmentUpdate updateDepartmentDTO, int id)
        //{
        //    if (updateDepartmentDTO == null)
        //    {
        //        return BadRequest("Department cannot be null.");
        //    }
        //    var dept = _context.Departments.Find(id);
        //    if (dept == null)
        //    {
        //        return NotFound("Department not found.");
        //    }
        //    _mapper.Map(updateDepartmentDTO, dept);

        //    _context.SaveChanges();

        //    return NoContent();
        //}


        //[HttpPatch]
        //public IActionResult UpdateName(int id, string name)
        //{

        //    var dept = _context.Departments.Find(id);
        //    if (dept == null)
        //    {
        //        return NotFound("DEp not ");
        //    }

        //    dept.Name = name;
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        ////9
        //[HttpGet("lest")]
        //public IActionResult GetAtlest(int depart)
        //{
        //    var teacher = _context.Teachers.Any(e => e.DepartmentId == depart);
        //    return Ok(teacher);
        //}


        ////14 
        //[HttpGet("{departmentId}/all-students")]
        //public IActionResult GetAllStudents(int departmentId)
        //{
        //    var students = _context.Departments
        //        .Where(d => d.Id == departmentId)
        //        .SelectMany(d => d.Teachers)
        //        .SelectMany(t => t.Subjects)
        //        .SelectMany(s => s.Enrollments)
        //        .Select(e => e.Student)
        //        .Distinct();

        //    return Ok(students);
        //}


    }
}