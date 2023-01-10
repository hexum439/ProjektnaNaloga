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
    public class OblacilasApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OblacilasApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OblacilasApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oblacila>>> GetOblacilas()
        {
            return await _context.Oblacilas.ToListAsync();
        }

        // GET: api/OblacilasApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oblacila>> GetOblacila(int id)
        {
            var oblacila = await _context.Oblacilas.FindAsync(id);

            if (oblacila == null)
            {
                return NotFound();
            }

            return oblacila;
        }

        // PUT: api/OblacilasApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOblacila(int id, Oblacila oblacila)
        {
            if (id != oblacila.Id)
            {
                return BadRequest();
            }

            _context.Entry(oblacila).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OblacilaExists(id))
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

        // POST: api/OblacilasApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oblacila>> PostOblacila(Oblacila oblacila)
        {
            _context.Oblacilas.Add(oblacila);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOblacila", new { id = oblacila.Id }, oblacila);
        }

        // DELETE: api/OblacilasApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOblacila(int id)
        {
            var oblacila = await _context.Oblacilas.FindAsync(id);
            if (oblacila == null)
            {
                return NotFound();
            }

            _context.Oblacilas.Remove(oblacila);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OblacilaExists(int id)
        {
            return _context.Oblacilas.Any(e => e.Id == id);
        }
    }
}
