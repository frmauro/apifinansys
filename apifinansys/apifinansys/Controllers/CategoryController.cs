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
    public class CategoryController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public CategoryController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _repoWrapper.CategoryRepository.FindAllAsync();
            return Ok(categories);
        }


        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            var categories = await _repoWrapper.CategoryRepository.FindByConditionAsync(c => c.Id == id);
            var category = categories.FirstOrDefault();

            if (category == null)
                return NotFound();

            return Ok(category);
        }


        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _repoWrapper.CategoryRepository.CreateAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }


        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category category)
        {
            if (id != category.Id)
                return BadRequest();

            await _repoWrapper.CategoryRepository.UpdateAsync(category);

            return NoContent();
        }


        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var categories = await _repoWrapper.CategoryRepository.FindByConditionAsync(c => c.Id == id);
            var category = categories.FirstOrDefault();

            if (category == null)
                return NotFound();

            await _repoWrapper.CategoryRepository.DeleteAsync(category);
            return NoContent();
        }
    }
}