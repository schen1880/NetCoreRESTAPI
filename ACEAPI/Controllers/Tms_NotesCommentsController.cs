using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACEAPI.Data;
using ACEAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ACEAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Tms_NotesCommentsController : ControllerBase
    {
        private readonly aceContext _context;

        public Tms_NotesCommentsController(aceContext context)
        {
            _context = context;
        }

        // GET: api/Tms_NotesComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tms_NotesComments>>> GetTms_NotesComments()
        {
            return await _context.Tms_NotesComments.ToListAsync();
        }

        // GET: api/Tms_NotesComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tms_NotesComments>> GetTms_NotesComments(int id)
        {
            var tms_NotesComments = await _context.Tms_NotesComments.FindAsync(id);

            if (tms_NotesComments == null)
            {
                return NotFound();
            }

            return tms_NotesComments;
        }


        // GET: api/Tms_NotesComments_ProcessId
        [HttpGet("ProcessId/{processId}")]
        public async Task<ActionResult<IEnumerable<Tms_NotesComments>>> GetTms_NotesComments_ProcessId(int processId)
        {
            return await _context.Tms_NotesComments.Where(x => x.ProcessId.Equals(processId)).ToListAsync();
        }



        // PUT: api/Tms_NotesComments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTms_NotesComments(int id, Tms_NotesComments tms_NotesComments)
        {
            if (id != tms_NotesComments.CommentId)
            {
                return BadRequest();
            }

            _context.Entry(tms_NotesComments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tms_NotesCommentsExists(id))
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

        // PUT: api/Tms_NotesComments/List
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("List")]
        public async Task<IActionResult> PutTms_NotesCommentsList(IEnumerable<Tms_NotesComments> tms_NotesComments)
        {
            foreach (var note in tms_NotesComments)
            {
                _context.Entry(note).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                foreach (var note in tms_NotesComments)
                {
                    if (!Tms_NotesCommentsExists(note.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }

        // POST: api/Tms_NotesComments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tms_NotesComments>> PostTms_NotesComments(Tms_NotesComments tms_NotesComments)
        {
            _context.Tms_NotesComments.Add(tms_NotesComments);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Tms_NotesCommentsExists(tms_NotesComments.CommentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTms_NotesComments", new { id = tms_NotesComments.CommentId }, tms_NotesComments);
        }

        // POST: api/Tms_NotesComments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("List")]
        public async Task<ActionResult<List<Tms_NotesComments>>> PostTms_NotesCommentsList(List<Tms_NotesComments> tms_NotesComments)
        {
            foreach (var note in tms_NotesComments)
            {
                _context.Tms_NotesComments.Add(note);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                foreach (var note in tms_NotesComments)
                {
                    if (Tms_NotesCommentsExists(note.CommentId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return tms_NotesComments;
        }

        // DELETE: api/Tms_NotesComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tms_NotesComments>> DeleteTms_NotesComments(int id)
        {
            var tms_NotesComments = await _context.Tms_NotesComments.FindAsync(id);
            if (tms_NotesComments == null)
            {
                return NotFound();
            }

            _context.Tms_NotesComments.Remove(tms_NotesComments);
            await _context.SaveChangesAsync();

            return tms_NotesComments;
        }

        private bool Tms_NotesCommentsExists(int id)
        {
            return _context.Tms_NotesComments.Any(e => e.CommentId == id);
        }
    }
}
