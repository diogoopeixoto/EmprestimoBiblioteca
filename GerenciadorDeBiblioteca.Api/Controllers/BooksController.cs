using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeBiblioteca.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private ILivroRepository _livrorepository;

        public BooksController(ILivroRepository repository)
        {
            _livrorepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroVO>>> GetAll()
        {
            var livro = await _livrorepository.GetAll();
            return Ok(livro);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroVO>> GetById(int id)
        {
            var livro = await _livrorepository.GetById(id);
            if (livro.Id <= 0) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<LivroVO>> Create(LivroVO vO)
        {
            if (vO == null) return BadRequest();
            var livro = await _livrorepository.Create(vO);

            return Ok(vO);
        }

        [HttpPut]
        public async Task<ActionResult<LivroVO>> Update(LivroVO vO)
        {
            if (vO == null) return BadRequest();
            var livro = await _livrorepository.Update(vO);

            return Ok(vO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _livrorepository.Delete(id);
            if (!status) return BadRequest();


            return Ok(status);
        }
    }
}
