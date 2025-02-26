using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPABD.DataContext;
using ProjetoPABD.DTOs;
using ProjetoPABD.Models;
using System.Security.Cryptography;

namespace ProjetoPABD.Controllers
{
    [ApiController]
    [Route("tags")]
    public class TagController : Controller
    {

        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaTags = await _context.Tag.ToListAsync();
                return Ok(listaTags);
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
                var tag = await _context.Tag.Where(p => p.ID_Tag == id).FirstOrDefaultAsync();
                if (tag == null)
                {
                    return NotFound("A tag não existe!");
                }
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TagDTO tagDTO)
        {
            try
            {
                var tag = new Tag()
                {
                    Nome = tagDTO.Nome,
                };

                await _context.Tag.AddAsync(tag);
                await _context.SaveChangesAsync();

                return Ok(tag);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao salvar: {ex.Message}\nStackTrace: {ex.StackTrace}\nInner Exception: {ex.InnerException?.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TagDTO tagDTO)
        {
            try
            {
                var tag = await _context.Tag.FindAsync(id);

                if (tag is null)
                {
                    return NotFound();
                }

                tag.Nome = tagDTO.Nome;

                _context.Tag.Update(tag);
                await _context.SaveChangesAsync();

                return Ok(tag);
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
                var tag = await _context.Tag.FindAsync(id);

                if (tag == null)
                {
                    return NotFound();
                }

                _context.Tag.Remove(tag);
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
