using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apifinansys.Contracts;
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
        private IRepositoryWrapper _repoWrapper;

        public EntryController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        // GET: api/Entry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetEntries()
        {
            var entries = await _repoWrapper.EntryRepository.FindAllAsync();
            return Ok(entries);
        }


        // GET: api/Entry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(long id)
        {
            var entries = await _repoWrapper.EntryRepository.FindByConditionAsync(e => e.Id == id);
            var entry = entries.FirstOrDefault();

            if (entry == null)
                return NotFound();

            return Ok(entry);
        }


        // POST: api/Entry
        [HttpPost]
        public async Task<ActionResult<Entry>> PostCategory(Entry entry)
        {
            await _repoWrapper.EntryRepository.CreateAsync(entry);
            return CreatedAtAction(nameof(GetEntry), new { id = entry.Id }, entry);
        }


        // PUT: api/Entry/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Entry entry)
        {
            if (id != entry.Id)
                return BadRequest();

            await _repoWrapper.EntryRepository.UpdateAsync(entry);

            return NoContent();
        }


        // DELETE: api/Entry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(long id)
        {
            var entries = await _repoWrapper.EntryRepository.FindByConditionAsync(e => e.Id == id);
            var entry = entries.FirstOrDefault();

            if (entry == null)
                return NotFound();

            await _repoWrapper.EntryRepository.DeleteAsync(entry);

            return NoContent();
        }

    }
}