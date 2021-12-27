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
    public class AuthorsController : ControllerBase
    {
        private IAuthor _author;
        private IMapper _mapper;

        public AuthorsController(IAuthor author, IMapper mapper)
        {
            _author = author;
            _mapper = mapper;
        }
        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var authors = await _author.GetAll();
            var dtos = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return Ok(dtos);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            var result = await _author.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(result));
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorForCreateDto authorForCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(authorForCreateDto);
                var result = await _author.Insert(author);
                var authorReturn = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(authorReturn);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(int id, [FromBody] AuthorForCreateDto authorToCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(authorToCreateDto);
                var result = await _author.Update(id.ToString(), author);
                var authordto = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(authordto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _author.Delete(id.ToString());
                return Ok($"Data author {id} berhasil di delete");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("byname")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetByName(string name)
        {
            var authors = await _author.GetByName(name);
            var dtos = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return Ok(dtos);
        }
        
        [HttpGet("courselist")]
        public async Task<IEnumerable<Author>> GetCourseByAuthor(string name)
        {
            var results = await _author.GetCourseByAuthor(name);
            return results;
        }
    }
}
