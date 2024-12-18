using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPABD.DataContext;
using ProjetoPABD.DTOs;
using ProjetoPABD.Models;
using System.Security.Cryptography;

namespace ProjetoPABD.Controllers
{
    [ApiController]
    [Route("perfis")]
    public class PerfilController : Controller
    {

        private readonly AppDbContext _context;
        public PerfilController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPerfis = await _context.Perfil.ToListAsync();
                return Ok(listaPerfis);
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
                var perfil = await _context.Perfil.Where(p => p.ID_Perfil == id).FirstOrDefaultAsync();
                if (perfil == null)
                {
                    return NotFound("Perfil não encontrado!");
                }
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                var perfil = new Perfil()
                {
                    Bio = perfilDTO.Bio,
                    Habilidades = perfilDTO.Habilidades,
                    Experiencias = perfilDTO.Experiencias,
                    ID_Usuario = perfilDTO.ID_Usuario,
                };

                await _context.Perfil.AddAsync(perfil);
                await _context.SaveChangesAsync();

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                var perfil = await _context.Perfil.FindAsync(id);

                if (perfil is null)
                {
                    return NotFound();
                }

                perfil.Bio = perfilDTO.Bio;
                perfil.Habilidades = perfilDTO.Habilidades;
                perfil.Experiencias = perfilDTO.Experiencias;

                _context.Perfil.Update(perfil);
                await _context.SaveChangesAsync();

                return Ok(perfil);
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
                var perfil = await _context.Perfil.FindAsync(id);

                if (perfil == null)
                {
                    return NotFound();
                }

                _context.Perfil.Remove(perfil);
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
