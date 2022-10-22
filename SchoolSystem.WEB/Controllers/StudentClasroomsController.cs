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
    public class StudentClasroomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentClasroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentClasrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentClasroom>>> GetStudentClasrooms()
        {
            return await _context.StudentClasrooms.ToListAsync();
        }

        // GET: api/StudentClasrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentClasroom>> GetStudentClasroom(Guid id)
        {
            var studentClasroom = await _context.StudentClasrooms.FindAsync(id);

            if (studentClasroom == null)
            {
                return NotFound();
            }

            return studentClasroom;
        }

        // PUT: api/StudentClasrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentClasroom(Guid id, StudentClasroom studentClasroom)
        {
            if (id != studentClasroom.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentClasroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentClasroomExists(id))
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

        // POST: api/StudentClasrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentClasroom>> PostStudentClasroom(StudentClasroom studentClasroom)
        {
            _context.StudentClasrooms.Add(studentClasroom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentClasroomExists(studentClasroom.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentClasroom", new { id = studentClasroom.StudentId }, studentClasroom);
        }

        // DELETE: api/StudentClasrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentClasroom(Guid id)
        {
            var studentClasroom = await _context.StudentClasrooms.FindAsync(id);
            if (studentClasroom == null)
            {
                return NotFound();
            }

            _context.StudentClasrooms.Remove(studentClasroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentClasroomExists(Guid id)
        {
            return _context.StudentClasrooms.Any(e => e.StudentId == id);
        }
    }
}
