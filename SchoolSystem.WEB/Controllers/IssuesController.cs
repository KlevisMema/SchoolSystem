using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Models;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {

        public IssuesController()
        {
        }

        //// GET: api/Issues
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        //{
        //    return await _context.Issues.ToListAsync();
        //}

        //// GET: api/Issues/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Issue>> GetIssue(Guid id)
        //{
        //    var issue = await _context.Issues.FindAsync(id);

        //    if (issue == null)
        //    {
        //        return NotFound();
        //    }

        //    return issue;
        //}

        //// PUT: api/Issues/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutIssue(Guid id, Issue issue)
        //{
        //    if (id != issue.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(issue).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IssueExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Issues
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Issue>> PostIssue(Issue issue)
        //{
        //    _context.Issues.Add(issue);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetIssue", new { id = issue.Id }, issue);
        //}

        //// DELETE: api/Issues/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteIssue(Guid id)
        //{
        //    var issue = await _context.Issues.FindAsync(id);
        //    if (issue == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Issues.Remove(issue);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool IssueExists(Guid id)
        //{
        //    return _context.Issues.Any(e => e.Id == id);
        //}
    }
}
