using AutoMapper;
using DTO;
using Entite;
using Microsoft.AspNetCore.Mvc;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IserviceCategory service;
        IMapper _mapper;

        public CategoryController(IserviceCategory _serviceCategory, IMapper mapper)
        {
            _mapper = mapper;
            service = _serviceCategory;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await service.GetCategories();
            List<CategoryDTO> categoriesDTO = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            return Ok(categoriesDTO);
            //return await service.GetCategories();
        }

        // GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Category>> Get(int id)
        //{
        //    return await service.GetCategoryById(id);

        //}

        // POST api/<CategoryController>
        //[HttpPost]
        //public async Task<ActionResult<Category>> Post([FromBody] Category category)
        //{
        //    Category newCategory = await service.AddCategory(category);
        //    if (newCategory != null)
        //        return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, newCategory);
        //    else
        //        return BadRequest();
        //}

        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody] Category value)
        //{
        //    await service.UpdateCategory(id, value);
        //}


        // DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
