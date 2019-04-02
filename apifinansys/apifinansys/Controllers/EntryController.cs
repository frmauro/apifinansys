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
        public  ActionResult<IEnumerable<Entry>> GetEntries()
        {
            return _repoWrapper.EntryRepository.FindAll().ToList();
        }


        // GET: api/Entry/5
        [HttpGet("{id}")]
        public ActionResult<Entry> GetEntry(long id)
        {
            var entry = _repoWrapper.EntryRepository.FindByCondition(e => e.Id == id).FirstOrDefault();

            if (entry == null)
                return NotFound();

            return entry;
        }


        // POST: api/Entry
        [HttpPost]
        public ActionResult<Entry> PostCategory(Entry entry)
        {
            _repoWrapper.EntryRepository.Create(entry);
            return CreatedAtAction(nameof(GetEntry), new { id = entry.Id }, entry);
        }


        // PUT: api/Entry/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(long id, Entry entry)
        {
            if (id != entry.Id)
                return BadRequest();

            _repoWrapper.EntryRepository.Update(entry);

            return NoContent();
        }


        // DELETE: api/Entry/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEntry(long id)
        {
            var entry = _repoWrapper.EntryRepository.FindByCondition(e => e.Id == id).FirstOrDefault();

            if (entry == null)
                return NotFound();

            _repoWrapper.EntryRepository.Delete(entry);

            return NoContent();
        }

    }
}