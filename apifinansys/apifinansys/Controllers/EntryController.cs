using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apifinansys.Contracts;
using apifinansys.DTO;
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
        public async Task<ActionResult<IEnumerable<EntryDto>>> GetEntries()
        {
            var entries = await _repoWrapper.EntryRepository.FindAllAsync();

            var entriesDto = new List<EntryDto>();

            entries.ToList().ForEach(e =>
            {
                var entryDto = new EntryDto
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Name = e.Name,
                    Paid = e.Paid,
                    Description = e.Description,
                    Date = e.Date.ToShortDateString(),
                    Type = e.Type
                };

                var categories = _repoWrapper.CategoryRepository.FindByConditionAsync(c => c.Id == e.Id);
                var category = categories.Result.FirstOrDefault();
                entryDto.CategoryId = category.Id;
                entryDto.CategoryName = category.Name;

                entriesDto.Add(entryDto);
            });

            return Ok(entriesDto);
        }


        // GET: api/Entry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntryDto>> GetEntry(long id)
        {
            var entries = await _repoWrapper.EntryRepository.FindByConditionAsync(e => e.Id == id);
            var entry = entries.FirstOrDefault();

            if (entry == null)
                return NotFound();

            var entryDto = new EntryDto
            {
                Id = entry.Id,
                Amount = entry.Amount,
                Name = entry.Name,
                Paid = entry.Paid,
                Description = entry.Description,
                Date = entry.Date.ToShortDateString(),
                Type = entry.Type
            };

            var categories = _repoWrapper.CategoryRepository.FindByConditionAsync(c => c.Id == entry.Id);
            var category = categories.Result.FirstOrDefault();
            entryDto.CategoryId = category.Id;
            entryDto.CategoryName = category.Name;

            return Ok(entryDto);
        }


        // POST: api/Entry
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(EntryDto entryDto)
        {
            var entry = new Entry
            {
                DataCriacao = DateTime.Now,
                Ativo = true,
                Name = entryDto.Name,
                Paid = entryDto.Paid,
                Type = entryDto.Type,
                Amount = entryDto.Amount,
                Description = entryDto.Description
            };
            entry.Date = entry.Date;

            var categories = await _repoWrapper.CategoryRepository.FindByConditionAsync(c => c.Id == entryDto.CategoryId);
            entry.Category = categories.FirstOrDefault();
            await _repoWrapper.EntryRepository.CreateAsync(entry);
            return CreatedAtAction(nameof(GetEntry), new { id = entry.Id }, entryDto);
        }


        // PUT: api/Entry/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry(long id, Entry entry)
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