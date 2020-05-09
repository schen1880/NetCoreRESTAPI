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
    public class Dbo_NAICSCodesController : ControllerBase
    {
        private readonly aceContext _context;

        public Dbo_NAICSCodesController(aceContext context)
        {
            _context = context;
        }

        // GET: api/Dbo_NAICSCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dbo_NAICSCodes>>> GetNaicscodes()
        {
            return await _context.Naicscodes.ToListAsync();
        }

        // GET: api/Dbo_NAICSCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dbo_NAICSCodes>> GetDbo_NAICSCodes(string id)
        {
            var dbo_NAICSCodes = await _context.Naicscodes.FindAsync(id);

            if (dbo_NAICSCodes == null)
            {
                return NotFound();
            }

            return dbo_NAICSCodes;
        }

        // PUT: api/Dbo_NAICSCodes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbo_NAICSCodes(string id, Dbo_NAICSCodes dbo_NAICSCodes)
        {
            if (id != dbo_NAICSCodes.Naicscode)
            {
                return BadRequest();
            }

            _context.Entry(dbo_NAICSCodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dbo_NAICSCodesExists(id))
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

        // POST: api/Dbo_NAICSCodes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dbo_NAICSCodes>> PostDbo_NAICSCodes(Dbo_NAICSCodes dbo_NAICSCodes)
        {
            _context.Naicscodes.Add(dbo_NAICSCodes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Dbo_NAICSCodesExists(dbo_NAICSCodes.Naicscode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbo_NAICSCodes", new { id = dbo_NAICSCodes.Naicscode }, dbo_NAICSCodes);
        }

        // DELETE: api/Dbo_NAICSCodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dbo_NAICSCodes>> DeleteDbo_NAICSCodes(string id)
        {
            var dbo_NAICSCodes = await _context.Naicscodes.FindAsync(id);
            if (dbo_NAICSCodes == null)
            {
                return NotFound();
            }

            _context.Naicscodes.Remove(dbo_NAICSCodes);
            await _context.SaveChangesAsync();

            return dbo_NAICSCodes;
        }

        private bool Dbo_NAICSCodesExists(string id)
        {
            return _context.Naicscodes.Any(e => e.Naicscode == id);
        }
    }
}
