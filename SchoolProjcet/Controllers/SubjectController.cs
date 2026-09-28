using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.AppContext;
using School.Models;
using SchoolProjcet.DTOS.StudentDto;
using SchoolProjcet.DTOS.SubDto;
using SchoolProjcet.Mapping;
using SchoolProjcet.Repo.Interface;

namespace SchoolProjcet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
            private readonly ISubjectRepo Repo;
            private readonly IMapper _mapper;
        public SubjectController(ISubjectRepo Repo, IMapper _mapper)
        {
            this.Repo = Repo;
            this._mapper = _mapper;
        }

        [HttpGet]
            public IActionResult GetAll()
            {
            var subject = Repo.GetAll();
                var subjectDTOs = _mapper.Map<List<SubjectDto>>(subject);
                return Ok(subjectDTOs);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var subject =Repo.GetById(id);
            if (subject == null)
                {
                    return NotFound($"Student with id {id} not found.");
                }
                var subjectd = _mapper.Map<SubjectDto>(subject);

                return Ok(subjectd);
            }
            [HttpPost("create")]
            public IActionResult Create(SubjectCreate s)
            {
                if (s == null)
                {
                    return BadRequest("subject data cannot be null.");
                }
                var student = _mapper.Map<Subject>(s);

                Repo.Create(student);
                Repo.save();
                return Ok(s);
            }





            [HttpPut("update/{id}")]
            public IActionResult Update(int id, SubjectDto student)
            {
                if (student == null)
                {
                    return BadRequest("subject data cannot be null.");
                }

                var existingStudent = Repo.GetById(id);
            if (existingStudent == null)
                {
                    return NotFound($"subject with id {id} not found.");
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
                    return NotFound($"subject with id {id} not found.");
                }
                var s = _mapper.Map<SubjectDto>(existingStudent);

                Repo.delete(id);
                Repo.save();
                return Ok(s);
            }
           
        }
    }



