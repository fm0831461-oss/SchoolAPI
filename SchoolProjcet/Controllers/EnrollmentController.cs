using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTOS.DeptDto;
using SchoolProjcet.DTOS.EnrollmentDTO;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {

        private readonly IEnrollmentRepo Repo;
        private readonly IMapper _mapper;
        public EnrollmentController(IEnrollmentRepo Repo, IMapper _mapper)
        {
            this.Repo = Repo;
            this._mapper = _mapper;
        }
        [HttpGet]
        public IActionResult GetEnrollment()
        {

            List<Enrollment> dept = Repo.GetAll();
            List<EnrollmentDto> EnrollDTOs = _mapper.Map<List<EnrollmentDto>>(dept);
            if (dept == null || dept.Count == 0)
            {
                return NotFound("No enrollment found.");
            }
            return Ok(EnrollDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dept = Repo.GetById(id);

            var dep = _mapper.Map<DepartmentDto>(dept);
            return Ok(dep);
        }


        [HttpPost]
        public IActionResult CreateDepartment(EnrollmentCreate createEnrollDTO)
        {
            if (createEnrollDTO == null)
            {
                return BadRequest("Enrollment cannot be null.");


            }
            var dep = _mapper.Map<Enrollment>(createEnrollDTO);
             Repo.Create(dep);
            Repo.save();
            return CreatedAtAction(nameof(GetById), new { id = dep.Id }, dep);
        }




        [HttpPut]
        public IActionResult UpdateDepartment(EnrollmentUpdate updateEnrollmentDTO, int id)
        {
            if (updateEnrollmentDTO == null)
            {
                return BadRequest("Enrollment cannot be null.");
            }
            var dept = Repo.GetById(id);
            if (dept == null)
            {
                return NotFound("Enrollment not found.");
            }
            _mapper.Map(updateEnrollmentDTO, dept);

            Repo.update(dept);
            Repo.save();

            return NoContent();
        }


        //[HttpPatch]
        //public IActionResult UpdateName(int id, int grad)
        //{

        //    var dept = _context.Enrollments.Find(id);
        //    if (dept == null)
        //    {
        //        return NotFound("DEp not ");
        //    }

        //    dept.Grade = grad;
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //16
//        [HttpGet("order-by-grade-desc")]
//        public IActionResult GetOrderById(int classId)
//        {
//            var enrollments = _context.Enrollments
//                .Where(e => e.Student.ClassRoomId == classId)
//                .OrderByDescending(e => e.Grade)
//                .ToList();
//            return Ok(enrollments);
//        }
//        //18
//        [HttpGet("order-by-classroom")]
//        public IActionResult OrderByClassRoom()
//        {
//            var Enrollment = _context.Enrollments.OrderBy(e => e.Student.ClassRoomId).ThenByDescending(e => e.Grade).ToList();

//            return Ok(Enrollment);
//        }


//        //20
//        [HttpGet("AVG")]
//        public IActionResult GetAverageGrade(int classId)
//        {
//            var average = _context.Enrollments
//                .Where(e => e.Student.ClassRoomId == classId)
//                .Average(e => e.Grade);
//            return Ok(average);
//        }
////21

//        [HttpGet("High")]
//        public IActionResult GetHighestGrade(int classId)
//        {
//            var highest = _context.Enrollments
//                .Where(e => e.Student.ClassRoomId == classId)
//                .Max(e => e.Grade);
//            return Ok(highest);
//        }


//        //22

//        [HttpGet("low")]
//        public IActionResult GetLowestGrade(int classId)
//        {
//            var lowest = _context.Enrollments
//                .Where(e => e.Student.ClassRoomId == classId)
//                .Min(e => e.Grade);
//            return Ok(lowest);
//        }


//        //23
//        [HttpGet("names-string")]
//        public IActionResult GetNamesString(int classRoomId)
//        {
//            var names = _context.Students
//                .Where(s => s.ClassRoomId == classRoomId)
//                .Select(s => s.FirstName + " " + s.LastName)
//                .ToList();

//            var result = string.Join(", ", names);

//            return Ok(result);
//        }


//        //24
//        [HttpGet("count-by-classroom")]
//        public IActionResult CountByClassRoom()
//        {
//            var result = _context.Students
//                .GroupBy(s => s.ClassRoomId)
//                .Select(g => new
//                {
//                    ClassRoomId = g.Key,
//                    StudentCount = g.Count()
//                })
//                .ToList();

//            return Ok(result);
//        }
//        //25
//        [HttpGet("unique-classrooms")]
//        public IActionResult GetUniqueClassrooms()
//        {
//            var classroomIds = _context.Students
//                .Select(s => s.ClassRoomId)
//                .Distinct()
//                .ToList();

//            return Ok(classroomIds);
//        }

    }
}

