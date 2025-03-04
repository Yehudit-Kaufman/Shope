using AutoMapper;
using DTO;
using Entite;
using Microsoft.AspNetCore.Mvc;
using Service;
using Microsoft.Extensions.Caching.Memory;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IserviceCategory service;
        IMapper _mapper;
        IMemoryCache cach;

        public CategoryController(IserviceCategory _serviceCategory, IMapper mapper, IMemoryCache _cach)
        {
            _mapper = mapper;
            service = _serviceCategory;
           cach = _cach;
        }




        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            if (!cach.TryGetValue("categories", out List<Category> categories))
            {
                categories = await service.GetCategories();
                cach.Set("categories", categories, TimeSpan.FromMinutes(30));
            }
            List<CategoryDTO> categoryDTOList = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            return categoryDTOList != null ? Ok(categoryDTOList) : BadRequest();
        }
    

    }
}
