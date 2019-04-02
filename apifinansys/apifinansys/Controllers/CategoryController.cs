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

        //private readonly FinansysContext _context;

        public CategoryController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _repoWrapper.CategoryRepository.FindAll().ToList();
        }


        // GET: api/Category/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(long id)
        {
            var category = _repoWrapper.CategoryRepository.FindByCondition(c => c.Id == id).FirstOrDefault();

            if (category == null)
                return NotFound();

            return category;
        }


        // POST: api/Category
        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            _repoWrapper.CategoryRepository.Create(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }


        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(long id, Category category)
        {
            if (id != category.Id)
                return BadRequest();

            _repoWrapper.CategoryRepository.Update(category);

            return NoContent();
        }


        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(long id)
        {
            var category = _repoWrapper.CategoryRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
            if (category == null)
                return NotFound();

            _repoWrapper.CategoryRepository.Delete(category);

            return NoContent();
        }
    }
}