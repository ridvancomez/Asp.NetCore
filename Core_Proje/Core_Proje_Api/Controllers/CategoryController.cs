using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            using var context = new Context();
            return Ok(context.Categories.ToList());

        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            using var context = new Context();
            var value = context.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var context = new Context();
            context.Add(p);
            context.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var context = new Context();
            var value = context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            context.Remove(value);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            using var context = new Context();
            var value = context.Categories.Find(p.CategoryId);
            if (value == null)
            {
                return NotFound();
            }
            value.CategoryName = p.CategoryName;
            context.Update(value);
            context.SaveChanges();
            return Ok();
        }
    }
}
