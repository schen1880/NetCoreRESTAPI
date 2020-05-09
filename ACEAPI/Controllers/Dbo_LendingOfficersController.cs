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
    public class Dbo_LendingOfficersController : ControllerBase
    {
        private readonly aceContext _context;

        public Dbo_LendingOfficersController(aceContext context)
        {
            _context = context;
        }

        // GET: api/Dbo_LendingOfficers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dbo_LendingOfficers>>> GetLendingOfficers()
        {
            return await _context.LendingOfficers.ToListAsync();
        }

        // GET: api/Dbo_LendingOfficers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dbo_LendingOfficers>> GetDbo_LendingOfficers(string id)
        {
            var dbo_LendingOfficers = await _context.LendingOfficers.FindAsync(id);

            if (dbo_LendingOfficers == null)
            {
                return NotFound();
            }

            return dbo_LendingOfficers;
        }

        // PUT: api/Dbo_LendingOfficers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbo_LendingOfficers(string id, Dbo_LendingOfficers dbo_LendingOfficers)
        {
            if (id != dbo_LendingOfficers.Username)
            {
                return BadRequest();
            }

            _context.Entry(dbo_LendingOfficers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dbo_LendingOfficersExists(id))
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

        // POST: api/Dbo_LendingOfficers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dbo_LendingOfficers>> PostDbo_LendingOfficers(Dbo_LendingOfficers dbo_LendingOfficers)
        {
            _context.LendingOfficers.Add(dbo_LendingOfficers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Dbo_LendingOfficersExists(dbo_LendingOfficers.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbo_LendingOfficers", new { id = dbo_LendingOfficers.Username }, dbo_LendingOfficers);
        }

        // DELETE: api/Dbo_LendingOfficers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dbo_LendingOfficers>> DeleteDbo_LendingOfficers(string id)
        {
            var dbo_LendingOfficers = await _context.LendingOfficers.FindAsync(id);
            if (dbo_LendingOfficers == null)
            {
                return NotFound();
            }

            _context.LendingOfficers.Remove(dbo_LendingOfficers);
            await _context.SaveChangesAsync();

            return dbo_LendingOfficers;
        }

        private bool Dbo_LendingOfficersExists(string id)
        {
            return _context.LendingOfficers.Any(e => e.Username == id);
        }
    }
}
