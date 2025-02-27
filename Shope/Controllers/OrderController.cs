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
    public class OrderController : ControllerBase
    {
        IServiceOrder service;
        IMapper _mapper;

        public OrderController(IServiceOrder _serviceUser, IMapper mapper)
        {
            service = _serviceUser;
            _mapper = mapper;
        }
        // GET: api/<OrderController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {

            Order order = await service.GetOrderById(id);
            if (order != null)
                return Ok(_mapper.Map<Order, OrderDTO>(order));
            return NotFound();

        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] PostOrderDTO order)
        {
            //Order neworder= _mapper.Map<AddOrderDTO, Order>(order);
            //Order newOrder = await service.AddOrder(neworder);

            //if (newOrder != null)
            //    return CreatedAtAction(nameof(Get), new { id = order.OrderId }, newOrder);
            //else
            //    return BadRequest();
            //return Ok(order);

            Order newOrder = await service.AddOrder(_mapper.Map<PostOrderDTO, Order>(order));
            if (newOrder != null)
                return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, _mapper.Map<Order,OrderDTO>(newOrder));
            return BadRequest();
        }

        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
