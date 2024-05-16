using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeBiblioteca.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public IUsuarioRepository _usuarioRepository;
        public UsersController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioVO>>> GetAll()
        {
            var usuario = await _usuarioRepository.GetAll();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioVO>> GetById(int id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            if (usuario.Id <= 0) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioVO>> Create(UsuarioVO vO)
        {
            if (vO == null) return BadRequest();
            var usuario = await _usuarioRepository.Create(vO);

            return Ok(vO);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioVO>> Update(UsuarioVO vO)
        {
            if (vO == null) return BadRequest();
            var usuario = await _usuarioRepository.Update(vO);

            return Ok(vO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _usuarioRepository.Delete(id);
            if (!status) return BadRequest();


            return Ok(status);
        }

    }
}
