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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPost = await _context.Post
                    .Include(p => p.Usuario)
                    .Include(p => p.Post_Pai)
                    .Select(p => new
                    {
                        p.ID_Post,
                        p.Tipo_Post,
                        p.Data_Publicacao,
                        p.Conteudo,
                        Post_Pai_ID = p.Post_Pai_ID,
                        Usuario = new
                        {
                            p.Usuario.ID_Usuario,
                            p.Usuario.Nome
                        },
                        Post_Pai = p.Post_Pai != null ? new
                        {
                            p.Post_Pai.ID_Post,
                            p.Post_Pai.Conteudo
                        } : null
                    })
                    .ToListAsync();

                return Ok(listaPost);
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDTO postDTO)
        {
            try
            {
                var post = new Post()
                {
                    Usuario_ID_Usuario = postDTO.ID_Usuario,
                    Tipo_Post = postDTO.Tipo_Post,
                    Conteudo = postDTO.Conteudo,
                    Post_Pai_ID = postDTO.Post_Pai_ID,
                };

                if (post == null || post.Usuario_ID_Usuario <= 0)
                {
                    return BadRequest("Post ou ID de usuário inválido.");
                }

                Console.WriteLine(post);    

                await _context.Post.AddAsync(post);
                await _context.SaveChangesAsync();

                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao salvar: {ex.Message}\nStackTrace: {ex.StackTrace}\nInner Exception: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Post postAtualizado)
        {
            if (id != postAtualizado.ID_Post)
                return BadRequest(new { message = "ID do post não corresponde." });

            try
            {
                var existingPost = await _context.Post.FindAsync(id);
                if (existingPost == null)
                    return NotFound(new { message = "Post não encontrado." });

                existingPost.Tipo_Post = postAtualizado.Tipo_Post ?? existingPost.Tipo_Post;
                existingPost.Conteudo = postAtualizado.Conteudo ?? existingPost.Conteudo;

                _context.Entry(existingPost).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar post.", error = ex.Message });
            }
        }


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
