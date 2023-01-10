using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondHand.Data;
using SecondHand.Models;

namespace SecondHand.Controllers_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObutevsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ObutevsApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ObutevsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Obutev>>> GetObutevs()
        {
            return await _context.Obutevs.ToListAsync();
        }

        // GET: api/ObutevsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Obutev>> GetObutev(int id)
        {
            var obutev = await _context.Obutevs.FindAsync(id);

            if (obutev == null)
            {
                return NotFound();
            }

            return obutev;
        }

        // PUT: api/ObutevsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObutev(int id, Obutev obutev)
        {
            if (id != obutev.Id)
            {
                return BadRequest();
            }

            _context.Entry(obutev).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObutevExists(id))
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

        // POST: api/ObutevsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Obutev>> PostObutev(Obutev obutev)
        {
            _context.Obutevs.Add(obutev);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObutev", new { id = obutev.Id }, obutev);
        }

        // DELETE: api/ObutevsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObutev(int id)
        {
            var obutev = await _context.Obutevs.FindAsync(id);
            if (obutev == null)
            {
                return NotFound();
            }

            _context.Obutevs.Remove(obutev);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObutevExists(int id)
        {
            return _context.Obutevs.Any(e => e.Id == id);
        }
    }
}
