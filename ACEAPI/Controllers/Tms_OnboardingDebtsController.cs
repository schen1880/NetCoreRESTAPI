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
    public class Tms_OnboardingDebtsController : ControllerBase
    {
        private readonly aceContext _context;

        public Tms_OnboardingDebtsController(aceContext context)
        {
            _context = context;
        }

        // GET: api/Tms_OnboardingDebts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tms_OnboardingDebts>>> GetOnboardingDebts()
        {
            return await _context.OnboardingDebts.ToListAsync();
        }

        // GET: api/Tms_OnboardingDebts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tms_OnboardingDebts>> GetTms_OnboardingDebts(int id)
        {
            var tms_OnboardingDebts = await _context.OnboardingDebts.FindAsync(id);

            if (tms_OnboardingDebts == null)
            {
                return NotFound();
            }

            return tms_OnboardingDebts;
        }

        //[Route("OnboardingId")]
        [HttpGet("OnboardingId/{onboardingid}")]
        public async Task<ActionResult<IEnumerable<Tms_OnboardingDebts>>> GetTms_OnboardingDebtsOnboardingId(int onboardingid)
        {
            var tms_OnboardingDebts = await _context.OnboardingDebts.Where(x => x.OnboardingId == onboardingid).ToListAsync<Tms_OnboardingDebts>();

            if (tms_OnboardingDebts == null)
            {
                return NotFound();
            }

            return tms_OnboardingDebts;
        }

        // PUT: api/Tms_OnboardingDebts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTms_OnboardingDebts(int id, Tms_OnboardingDebts tms_OnboardingDebts)
        {
            if (id != tms_OnboardingDebts.DebtId)
            {
                return BadRequest();
            }

            _context.Entry(tms_OnboardingDebts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tms_OnboardingDebtsExists(id))
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

        // PUT: api/Tms_OnboardingDebts/List
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("List")]
        public async Task<IActionResult> PutTms_OnboardingDebtsList(IEnumerable<Tms_OnboardingDebts> tms_OnboardingDebts)
        {
            foreach (var debt in tms_OnboardingDebts)
            {
                _context.Entry(debt).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                foreach (var debt in tms_OnboardingDebts)
                {
                    if (!Tms_OnboardingDebtsExists(debt.DebtId))
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

        // POST: api/Tms_OnboardingDebts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tms_OnboardingDebts>> PostTms_OnboardingDebts(Tms_OnboardingDebts tms_OnboardingDebts)
        {
            _context.OnboardingDebts.Add(tms_OnboardingDebts);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Tms_OnboardingDebtsExists(tms_OnboardingDebts.DebtId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTms_OnboardingDebts", new { id = tms_OnboardingDebts.DebtId }, tms_OnboardingDebts);
        }

        // POST: api/Tms_OnboardingDebts/List
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("List")]
        public async Task<ActionResult<List<Tms_OnboardingDebts>>> PostTms_OnboardingDebtsList(List<Tms_OnboardingDebts> tms_OnboardingDebts)
        {
            foreach (var debt in tms_OnboardingDebts)
            {
                _context.OnboardingDebts.Add(debt);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                foreach (var debt in tms_OnboardingDebts)
                {
                    if (Tms_OnboardingDebtsExists(debt.DebtId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return tms_OnboardingDebts;
        }

        // DELETE: api/Tms_OnboardingDebts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tms_OnboardingDebts>> DeleteTms_OnboardingDebts(int id)
        {
            var tms_OnboardingDebts = await _context.OnboardingDebts.FindAsync(id);
            if (tms_OnboardingDebts == null)
            {
                return NotFound();
            }

            _context.OnboardingDebts.Remove(tms_OnboardingDebts);
            await _context.SaveChangesAsync();

            return tms_OnboardingDebts;
        }

        private bool Tms_OnboardingDebtsExists(int id)
        {
            return _context.OnboardingDebts.Any(e => e.DebtId == id);
        }
    }
}
