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

namespace ACEAPI
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Dbo_RelationshipManagersController : ControllerBase
    {
        private readonly aceContext _context;

        public Dbo_RelationshipManagersController(aceContext context)
        {
            _context = context;
        }

        // GET: api/Dbo_RelationshipManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dbo_RelationshipManagers>>> GetRelationshipManagers()
        {
            return await _context.RelationshipManagers.ToListAsync();
        }

        // GET: api/Dbo_RelationshipManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dbo_RelationshipManagers>> GetDbo_RelationshipManagers(string id)
        {
            var dbo_RelationshipManagers = await _context.RelationshipManagers.FindAsync(id);

            if (dbo_RelationshipManagers == null)
            {
                return NotFound();
            }

            return dbo_RelationshipManagers;
        }

        // PUT: api/Dbo_RelationshipManagers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbo_RelationshipManagers(string id, Dbo_RelationshipManagers dbo_RelationshipManagers)
        {
            if (id != dbo_RelationshipManagers.Username)
            {
                return BadRequest();
            }

            _context.Entry(dbo_RelationshipManagers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dbo_RelationshipManagersExists(id))
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

        // POST: api/Dbo_RelationshipManagers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dbo_RelationshipManagers>> PostDbo_RelationshipManagers(Dbo_RelationshipManagers dbo_RelationshipManagers)
        {
            _context.RelationshipManagers.Add(dbo_RelationshipManagers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Dbo_RelationshipManagersExists(dbo_RelationshipManagers.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbo_RelationshipManagers", new { id = dbo_RelationshipManagers.Username }, dbo_RelationshipManagers);
        }

        // DELETE: api/Dbo_RelationshipManagers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dbo_RelationshipManagers>> DeleteDbo_RelationshipManagers(string id)
        {
            var dbo_RelationshipManagers = await _context.RelationshipManagers.FindAsync(id);
            if (dbo_RelationshipManagers == null)
            {
                return NotFound();
            }

            _context.RelationshipManagers.Remove(dbo_RelationshipManagers);
            await _context.SaveChangesAsync();

            return dbo_RelationshipManagers;
        }

        private bool Dbo_RelationshipManagersExists(string id)
        {
            return _context.RelationshipManagers.Any(e => e.Username == id);
        }
    }
}
