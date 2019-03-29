using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apifinansys.EFContext;
using apifinansys.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apifinansys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly FinansysContext _context;

        public EntryController(FinansysContext context)
        {
            this._context = context;
        }

        // GET: api/Entry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetEntries()
        {
            return await _context.Entries.ToListAsync();
        }


        // GET: api/Entry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(long id)
        {
            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
                return NotFound();

            return entry;
        }


        // POST: api/Entry
        [HttpPost]
        public async Task<ActionResult<Entry>> PostCategory(Entry entry)
        {
            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntry), new { id = entry.Id }, entry);
        }


        // PUT: api/Entry/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Entry entry)
        {
            if (id != entry.Id)
                return BadRequest();

            _context.Entry(entry).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Entry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(long id)
        {
            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
                return NotFound();

            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}