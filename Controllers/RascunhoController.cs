using ProjetoPABD.DataContext;
using ProjetoPABD.DTOs;
using ProjetoPABD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPABD.Controllers
{
    [ApiController]
    [Route("rascunhos")]
    public class RascunhoController : Controller
    {

        private readonly AppDbContext _context;

        public RascunhoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaRascunhos = await _context.Rascunho.ToListAsync();
                return Ok(listaRascunhos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var rascunho = await _context.Rascunho.Where(r => r.ID_Rascunho == id).FirstOrDefaultAsync();
                if (rascunho == null)
                {
                    return NotFound("Rascunho não encontrado.");
                }
                return Ok(rascunho);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RascunhoDTO rascunhoDTO)
        {
            try
            {
                var rascunho = new Rascunho()
                {
                    Usuario_ID_Usuario = rascunhoDTO.ID_Usuario,
                    Conteudo = rascunhoDTO.Conteudo,
                };

                await _context.Rascunho.AddAsync(rascunho);
                await _context.SaveChangesAsync();
                return Ok(rascunho);
            }

            catch (Exception ex)
            {
                return BadRequest($"Erro ao salvar: {ex.Message}\nStackTrace: {ex.StackTrace}\nInner Exception: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RascunhoDTO rascunhoDTO)
        {
            try
            {
                var rascunho = await _context.Rascunho.FindAsync(id);

                if (rascunho is null)
                {
                    return NotFound();
                }

                rascunho.Conteudo = rascunhoDTO.Conteudo;
                rascunho.Data_Edicao = rascunhoDTO.Data_Edicao;

                _context.Rascunho.Update(rascunho);
                await _context.SaveChangesAsync();

                return Ok(rascunho);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var rascunho = await _context.Rascunho.FindAsync(id);

                if (rascunho == null)
                {
                    return NotFound();
                }

                _context.Rascunho.Remove(rascunho);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}