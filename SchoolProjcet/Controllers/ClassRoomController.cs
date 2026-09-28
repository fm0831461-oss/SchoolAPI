using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTOS.ClassRoomDTO;
using SchoolProjcet.DTOS.SubDto;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomRepo Repo;
        private readonly IMapper _mapper;
        public ClassRoomController(IClassRoomRepo Repo, IMapper _mapper)
        {
          
            this.Repo = Repo;
            this._mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var classRooms = Repo.GetAll();
            var classRoomDTOs = _mapper.Map<List<ClassRoomDto>>(classRooms);
            return Ok(classRoomDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classRoom =Repo.GetById(id);
            if (classRoom == null)
            {
                return NotFound($"class room with id {id} not found.");
            }
            var classRoomDto = _mapper.Map<ClassRoomDto>(classRoom);

            return Ok(classRoomDto);
        }
        [HttpPost("create")]
        public IActionResult Create(ClassRoomCreate s)
        {
            if (s == null)
            {
                return BadRequest("class room data cannot be null.");
            }
            var classRoom = _mapper.Map<ClassRoom>(s);

            Repo.Create(classRoom);
            Repo.save();
            return Ok(s);
        }





        [HttpPut("update/{id}")]
        public IActionResult Update(int id, ClassRoomUpdate student)
        {
            if (student == null)
            {
                return BadRequest("class room data cannot be null.");
            }

            var existingStudent = Repo.GetById(id);
            if (existingStudent == null)
            {
                return NotFound($"class room with id {id} not found.");
            }

            existingStudent = _mapper.Map(student, existingStudent);

            Repo.update(existingStudent);
            Repo.save();
            return Ok(student);
        }



        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = Repo.GetById(id);
            if (existingStudent == null)
            {
                return NotFound($"clas room with id {id} not found.");
            }
            var s = _mapper.Map<ClassRoom>(existingStudent);

            Repo.delete(id);
            Repo.save();
            return Ok(s);
        }
        ////10
        //[HttpGet("{classRoomId}/all-have-phone")]
        //public IActionResult AllHavePhone(int classRoomId)
        //{
        //    var result = _context.Students
        //        .Where(s => s.ClassRoomId == classRoomId)
        //        .All(s => s.PhoneNumber != null && s.PhoneNumber != "");

        //    return Ok(result);
        //}
        
    }
}

