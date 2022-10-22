using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.DataBase;
using SchoolSystem.DAL.Models;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasroomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClasroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clasrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clasroom>>> GetClasrooms()
        {
            return await _context.Clasrooms.ToListAsync();
        }

        // GET: api/Clasrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clasroom>> GetClasroom(Guid id)
        {
            var clasroom = await _context.Clasrooms.FindAsync(id);

            if (clasroom == null)
            {
                return NotFound();
            }

            return clasroom;
        }

        // PUT: api/Clasrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasroom(Guid id, Clasroom clasroom)
        {
            if (id != clasroom.Id)
            {
                return BadRequest();
            }

            _context.Entry(clasroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasroomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clasrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clasroom>> PostClasroom(Clasroom clasroom)
        {
            _context.Clasrooms.Add(clasroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasroom", new { id = clasroom.Id }, clasroom);
        }

        // DELETE: api/Clasrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasroom(Guid id)
        {
            var clasroom = await _context.Clasrooms.FindAsync(id);
            if (clasroom == null)
            {
                return NotFound();
            }

            _context.Clasrooms.Remove(clasroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasroomExists(Guid id)
        {
            return _context.Clasrooms.Any(e => e.Id == id);
        }
    }
}
