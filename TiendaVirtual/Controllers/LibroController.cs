using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Contexts;
using TiendaVirtual.Entities;

namespace TiendaVirtual.Controllers
{
    [Route("api/Libros")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public LibroController(LibreriaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> Get()
        {

            using(var _contextDb = _context)
            {
                return await _contextDb.Libros.Include(l => l.Autor).ToListAsync();
            }

        }

        [HttpGet("{id}", Name = "ObtenerLibro")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            using(var db = _context)
            {
                var libro = await db.Libros.FirstOrDefaultAsync(a => a.Id == id);
                return Ok(libro);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Libro libro)
        {

            try
            {
                   using(var db = _context)
            {
                var autor = await db.Autores.FirstOrDefaultAsync(a => a.Id == libro.IdAutor);
                if(autor == null)
                {
                    return NotFound("No se pudo crear el libro ya que dicho autor no existe");
                }

                await db.Libros.AddAsync(libro);
                await db.SaveChangesAsync();

                return new CreatedAtRouteResult("ObtenerLibro", new { id  = libro.Id },libro);
            }
            }
            catch (Exception error)
            {

               return BadRequest(error.Message);
            }
        
        }


    }
}
