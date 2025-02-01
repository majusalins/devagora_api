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


    }
}
