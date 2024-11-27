using ProjetoPABD.DataContext;
using ProjetoPABD.DTOs;
using ProjetoPABD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ProjetoPABD.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : Controller
    {

        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaUsuarios = await _context.Usuario.ToListAsync();
                return Ok(listaUsuarios);
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
                var usuario = await _context.Usuario.Where(u => u.ID_Usuario == id).FirstOrDefaultAsync();
                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado!");
                }

                return Ok(usuario);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO item)
        {
            try
            {
                var usuario = new Usuario()
                {
                    Nome = item.Nome,
                    Email = item.Email,
                    Senha = item.Senha,
                    Data_Cadastro = DateTime.Now,
                    Tipo_Usuario = false,
                };

                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDTO item)
        {

            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario is null)
                {
                    return NotFound();
                }

                usuario.Nome = item.Nome;
                usuario.Email = item.Email;
                usuario.Senha = item.Senha;

                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);
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
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario is null)
                {
                    return NotFound();
                }

                _context.Usuario.Remove(usuario);
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