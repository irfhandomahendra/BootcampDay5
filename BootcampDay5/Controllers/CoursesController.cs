using AutoMapper;
using BootcampDay5.Data;
using BootcampDay5.Dtos;
using BootcampDay5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BootcampDay5.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var courses = await _course.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(dtos);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<CourseDto>(result));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto courseforCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseforCreateDto);
                var result = await _course.Insert(course);
                var courseReturn = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(courseReturn);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForCreateDto courseToCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseToCreateDto);
                var result = await _course.Update(id.ToString(), course);
                var coursedto = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(coursedto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"Data course {id} berhasil di delete");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byname")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetByName(string name)
        {
            var results = await _course.GetByName(name);
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(results);
            return Ok(dtos);
        }
    }
}
