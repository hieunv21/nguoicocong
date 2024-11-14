using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KienGiangApplication.Models;

namespace KienGiangApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiCoCongsController : ControllerBase
    {
        private readonly NguoiCoCongContext _context;

        public NguoiCoCongsController(NguoiCoCongContext context)
        {
            _context = context;
        }

        // GET: api/NguoiCoCongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiCoCong>>> GetNguoiCoCongs()
        {
            return await _context.NguoiCoCongs.ToListAsync();
        }

        // GET: api/NguoiCoCongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiCoCong>> GetNguoiCoCong(long id)
        {
            var nguoiCoCong = await _context.NguoiCoCongs.FindAsync(id);

            if (nguoiCoCong == null)
            {
                return NotFound();
            }

            return nguoiCoCong;
        }

        // PUT: api/NguoiCoCongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiCoCong(long id, NguoiCoCong nguoiCoCong)
        {
            if (id != nguoiCoCong.Id)
            {
                return BadRequest();
            }

            _context.Entry(nguoiCoCong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiCoCongExists(id))
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

        // POST: api/NguoiCoCongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NguoiCoCong>> PostNguoiCoCong(NguoiCoCong nguoiCoCong)
        {
            _context.NguoiCoCongs.Add(nguoiCoCong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoiCoCong", new { id = nguoiCoCong.Id }, nguoiCoCong);
        }

        // DELETE: api/NguoiCoCongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoiCoCong(long id)
        {
            var nguoiCoCong = await _context.NguoiCoCongs.FindAsync(id);
            if (nguoiCoCong == null)
            {
                return NotFound();
            }

            _context.NguoiCoCongs.Remove(nguoiCoCong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoiCoCongExists(long id)
        {
            return _context.NguoiCoCongs.Any(e => e.Id == id);
        }
    }
}
