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
    public class Tms_DepositsController : ControllerBase
    {
        private readonly aceContext _context;

        public Tms_DepositsController(aceContext context)
        {
            _context = context;
        }

        // GET: api/Tms_Deposits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tms_Deposits>>> GetTms_Deposits()
        {
            return await _context.Tms_Deposits.ToListAsync();
        }

        // GET: api/Tms_Deposits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tms_Deposits>> GetTms_Deposits(int id)
        {
            var tms_Deposits = await _context.Tms_Deposits.FindAsync(id);

            if (tms_Deposits == null)
            {
                return NotFound();
            }

            return tms_Deposits;
        }

        // PUT: api/Tms_Deposits/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTms_Deposits(int id, Tms_Deposits tms_Deposits)
        {
            if (id != tms_Deposits.DepositId)
            {
                return BadRequest();
            }

            _context.Entry(tms_Deposits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tms_DepositsExists(id))
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

        // PUT: api/Tms_Deposits/List
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("List")]
        public async Task<IActionResult> PutTms_DepositsList(IEnumerable<Tms_Deposits> tms_Deposits)
        {
            foreach(var deposit in tms_Deposits)
            {
                _context.Entry(deposit).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                foreach(var deposit in tms_Deposits)
                {
                    if (!Tms_DepositsExists(deposit.DepositId))
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

        // POST: api/Tms_Deposits
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tms_Deposits>> PostTms_Deposits(Tms_Deposits tms_Deposits)
        {
            _context.Tms_Deposits.Add(tms_Deposits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTms_Deposits", new { id = tms_Deposits.DepositId }, tms_Deposits);
        }

        // POST: api/Tms_Deposits/List
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("List")]
        public async Task<ActionResult<List<Tms_Deposits>>> PostTms_DepositsList(List<Tms_Deposits> tms_Deposits)
        {
            foreach (var deposit in tms_Deposits)
            {
                _context.Tms_Deposits.Add(deposit);
            }
            await _context.SaveChangesAsync();

            return tms_Deposits;
        }

        // DELETE: api/Tms_Deposits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tms_Deposits>> DeleteTms_Deposits(int id)
        {
            var tms_Deposits = await _context.Tms_Deposits.FindAsync(id);
            if (tms_Deposits == null)
            {
                return NotFound();
            }

            _context.Tms_Deposits.Remove(tms_Deposits);
            await _context.SaveChangesAsync();

            return tms_Deposits;
        }

        private bool Tms_DepositsExists(int id)
        {
            return _context.Tms_Deposits.Any(e => e.DepositId == id);
        }
    }
}
