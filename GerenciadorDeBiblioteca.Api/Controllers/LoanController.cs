using GerenciadorDeBiblioteca.Api.Data.ValueObjects;
using GerenciadorDeBiblioteca.Api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeBiblioteca.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoanController : Controller
    {
        public IEmprestimoRepository _emprestimoRepository;
        public LoanController(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmprestimoVO>>> GetAll()
        {
            var emprestimo = await _emprestimoRepository.GetAll();
            return Ok(emprestimo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmprestimoVO>> GetById(int id)
        {
            var emprestimo = await _emprestimoRepository.GetById(id);
            if (emprestimo.Id <= 0) return NotFound();
            return Ok(emprestimo);
        }

        [HttpPost]
        public async Task<ActionResult<EmprestimoVO>> Create(EmprestimoVO vO)
         {
            if (vO == null) return BadRequest();
            var emprestimo = await _emprestimoRepository.Create(vO);

            return Ok(vO);
        }

        [HttpPut]
        public async Task<ActionResult<EmprestimoVO>> Update(EmprestimoVO vO)
        {
            if (vO == null) return BadRequest();
            var emprestimo = await _emprestimoRepository.Update(vO);

            return Ok(vO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _emprestimoRepository.Delete(id);
            if (!status) return BadRequest();


            return Ok(status);
        }

    }
}

  
