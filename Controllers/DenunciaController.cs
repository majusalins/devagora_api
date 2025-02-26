using ProjetoPABD.DataContext;
using ProjetoPABD.DTOs;
using ProjetoPABD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPABD.Controllers
{
    [ApiController]
    [Route("denuncia")]
    public class DenunciaController : Controller
    {
        private readonly AppDbContext _context;

        public DenunciaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaDenuncia = await _context.Denuncia
                    .Include(d => d.Usuario)
                    .Include(d => d.Post)
                    .Select(d => new
                    {
                        d.ID_Denuncia,
                        d.Data_Denuncia,
                        d.Motivo,
                        Usuario = new
                        {
                            d.Usuario.ID_Usuario,
                            d.Usuario.Nome
                        },
                        Post = d.Post != null ? new
                        {
                            d.Post.ID_Post,
                            d.Post.Conteudo
                        } : null
                    })
                    .ToListAsync();

                return Ok(listaDenuncia);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var denuncia = await _context.Denuncia.FindAsync(id);
                if (denuncia == null)
                    return NotFound(new { message = "Denúncia não encontrada." });

                return Ok(denuncia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao buscar denúncia.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DenunciaDTO denunciaDTO)
        {
            try
            {
                var denuncia = new Denuncia()
                {
                    Usuario_ID_Usuario = denunciaDTO.ID_Usuario,
                    Motivo = denunciaDTO.Motivo,
                    Post_ID_Post = denunciaDTO.Post_ID_Post,
                };

                if (denuncia == null || denuncia.Usuario_ID_Usuario <= 0)
                {
                    return BadRequest("Denúncia ou ID de usuário inválido.");
                }

                await _context.Denuncia.AddAsync(denuncia);
                await _context.SaveChangesAsync();

                return Ok(denuncia);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao salvar: {ex.Message}\nStackTrace: {ex.StackTrace}\nInner Exception: {ex.InnerException?.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var denuncia = await _context.Denuncia.FindAsync(id);
                if (denuncia == null)
                    return NotFound(new { message = "Denúncia não encontrada." });

                _context.Denuncia.Remove(denuncia);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao excluir denúncia.", error = ex.Message });
            }
        }
    }
}
