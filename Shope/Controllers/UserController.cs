using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entite;
using Service;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        IServiceUser service ;
        IMapper _mapper;

        public UserController(IServiceUser _serviceUser,IMapper mapper)
        {
            service = _serviceUser;
            _mapper = mapper;
        }
        
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user=await service.GetUserById(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return Ok(userDTO);
        }

        // POST api/<UserController>
        [HttpPost]
        //public ActionResult<User> Post([FromBody] User user)
        //{
        //    User newUser = service.AddUser(user);
        //    return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUser);

        //}
        public async Task<ActionResult<UserDTO>>  Post([FromBody] RegisterUserDTO user)
        {
            User newUser = _mapper.Map<RegisterUserDTO, User>(user);
            User userDTO = await service.AddUser(newUser);

            UserDTO newUserDTO = _mapper.Map<User, UserDTO>(userDTO);//////////////////////////////////////////////////////////
            if (newUserDTO != null)
                return CreatedAtAction(nameof(Get), new { id = user.UserName }, newUserDTO);
            else
                return BadRequest(newUserDTO);


        }
        [HttpPost]
        [Route("password")]
        public int PostPassword([FromQuery] string password)
        {

            return service.CheckPassword(password);

        }

        [HttpPost("login")]
        public async  Task<ActionResult<UserDTO>>  PostLogin([FromQuery] string UserName,string Password)
        {
            User user = await service.Login(UserName, Password);

            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
                    if(userDTO != null)
                        return Ok(userDTO);       
            return NoContent();


        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDTO value)
        {
            User user= _mapper.Map<UserDTO,User>(value);
            await service.UpdateUser(id, user);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
