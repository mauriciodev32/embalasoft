using LivrosAPI.Models;
using LivrosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
       
        private readonly LivroService _service;

        public LivrosController(LivroService service) 
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var livros = _service.GetAll();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _service.GetById(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Livro livro)
        {
            _service.Add(livro);
            return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Livro livro)
        {
            var livroExistente = _service.GetById(id);
            if (livroExistente == null) return NotFound();

            _service.Update(id, livro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var livro = _service.GetById(id);
            if (livro == null) return NotFound();

            _service.Delete(id);
            return NoContent();
        }
    }
}
