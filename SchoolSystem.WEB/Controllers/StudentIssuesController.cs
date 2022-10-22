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
    public class StudentIssuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentIssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentIssue>>> GetStudentIssues()
        {
            return await _context.StudentIssues.ToListAsync();
        }

        // GET: api/StudentIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentIssue>> GetStudentIssue(Guid id)
        {
            var studentIssue = await _context.StudentIssues.FindAsync(id);

            if (studentIssue == null)
            {
                return NotFound();
            }

            return studentIssue;
        }

        // PUT: api/StudentIssues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentIssue(Guid id, StudentIssue studentIssue)
        {
            if (id != studentIssue.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentIssueExists(id))
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

        // POST: api/StudentIssues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentIssue>> PostStudentIssue(StudentIssue studentIssue)
        {
            _context.StudentIssues.Add(studentIssue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentIssueExists(studentIssue.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentIssue", new { id = studentIssue.StudentId }, studentIssue);
        }

        // DELETE: api/StudentIssues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentIssue(Guid id)
        {
            var studentIssue = await _context.StudentIssues.FindAsync(id);
            if (studentIssue == null)
            {
                return NotFound();
            }

            _context.StudentIssues.Remove(studentIssue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentIssueExists(Guid id)
        {
            return _context.StudentIssues.Any(e => e.StudentId == id);
        }
    }
}
