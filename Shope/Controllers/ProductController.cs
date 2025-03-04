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
        private readonly ILogger<ProductController> _logger;
        IServiceProduct service;
        IMapper _mapper;
        public ProductController(IServiceProduct _serviceUser,IMapper mapper,ILogger<ProductController>logger)
        {
            _logger = logger;
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

   
    }
}
