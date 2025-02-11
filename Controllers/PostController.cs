using ProjetoPABD.DataContext;
using ProjetoPABD.DTOs;
using ProjetoPABD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPABD.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        // Obter todos os posts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPost = await _context.Post.ToListAsync();
                return Ok(listaPost);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao buscar posts.", error = ex.Message });
            }
        }

        // Obter um post específico pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var post = await _context.Post.FindAsync(id);
                if (post == null)
                    return NotFound(new { message = "Post não encontrado." });

                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao buscar post.", error = ex.Message });
            }
        }

        // Criar um novo post
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            try
            {
                _context.Post.Add(post);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = post.ID_Post }, post);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao criar post.", error = ex.Message });
            }
        }

        // Atualizar um post existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Post postAtualizado)
        {
            if (id != postAtualizado.ID_Post)
                return BadRequest(new { message = "ID do post não corresponde." });

            try
            {
                _context.Entry(postAtualizado).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar post.", error = ex.Message });
            }
        }

        // Deletar um post
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var post = await _context.Post.FindAsync(id);
                if (post == null)
                    return NotFound(new { message = "Post não encontrado." });

                _context.Post.Remove(post);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao excluir post.", error = ex.Message });
            }
        }
    }
}
