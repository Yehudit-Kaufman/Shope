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
    public class ProductController : ControllerBase
    {
        IServiceProduct service;
        IMapper _mapper;
        public ProductController(IServiceProduct _serviceUser,IMapper mapper)
        {
            _mapper = mapper; 
            service = _serviceUser;
        }
        
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = await service.GetProducts(desc,minPrice, maxPrice, categoryIds);
            List<ProductDTO> productsDTO = _mapper.Map<List<Product>, List<ProductDTO>>(products);
            return Ok(productsDTO);
            //return await service.GetProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            Product product =await service.GetProductById(id);
            return  _mapper.Map<Product, ProductDTO>(product);

        }

        //// POST api/<ProductController>
        //[HttpPost]
        //public async Task<ActionResult<Product>> Post([FromBody] Product product)
        //{
        //    Product newProduct = await service.AddProduct(product);
        //    if (newProduct != null)
        //        return CreatedAtAction(nameof(Get), new { id = product.ProductId }, newProduct);
        //    else
        //        return BadRequest();
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody] Product value)
        //{
        //    await service.UpdateProduct(id, value);
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
