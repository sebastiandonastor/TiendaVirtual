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
    [Route("api/Autor")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public AutoresController(LibreriaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> Get()
        {
            var autores = await _context.Autores.ToListAsync();
            return autores;
        }

        [HttpGet("{id}" , Name = "ObtenerAutor")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if (autor == null)
            {
                return NotFound("Id inexistentee");
            }

            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] Autor autor)
        {
            await _context.Autores.AddAsync(autor);

            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id } , autor);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Autor autor)
        {
            
            if(id != autor.Id)
            {
                return BadRequest("El id del autor que desea actualziar y el id del autor enviado no es el mismo");
            }

            _context.Entry(autor).State =EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if(autor == null)
            {
                return NotFound("El autor que quiere eliminar no existe");
            }
            
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return Ok(autor);
        }


    }
}
