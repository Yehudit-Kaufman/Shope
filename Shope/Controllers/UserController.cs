﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<UserController> _logger;

        IServiceUser service ;
        IMapper _mapper;

        public UserController(IServiceUser _serviceUser,IMapper mapper,ILogger<UserController>logger)
        {
            _logger = logger;
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
        public async Task<ActionResult<RegisterUserDTO>> Get(int id)
        {
            User user=await service.GetUserById(id);
            RegisterUserDTO userDTO = _mapper.Map<User, RegisterUserDTO>(user);
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
            //else
            //    if (!ModelState.IsValid)

            //{

            //    var errors = ModelState.SelectMany(ms => ms.Value.Errors)

            //    .Select(error => error.ErrorMessage)

            //    .ToList();

            //    return BadRequest(errors); // מחזיר את השגיאות

            //}
            //else
            //    throw new Exception("password week");

            return BadRequest("Password week");


        }
        [HttpPost]
        [Route("password")]
        public IActionResult PostPassword([FromQuery] string password)
        {

            int score = service.CheckPassword(password);
            return score < 3 ? BadRequest(score) : Ok(score);
        }

       

        [HttpPost("login")]
        public async  Task<ActionResult<UserDTO>>  PostLogin([FromQuery] string UserName,string Password)
        {

            User user = await service.Login(UserName, Password);
            Console.WriteLine(user);

            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
                    if(userDTO != null)
            {
                _logger.LogInformation($"login attempted with userName,{UserName} and Password {Password}");
                    return Ok(userDTO);  
            }

            return NoContent();


        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] RegisterUserDTO value)
        {  
            User user= _mapper.Map<RegisterUserDTO, User>(value);
            User userUpdate = await service.UpdateUser(id, user);
            if (userUpdate != null)   
            return Ok();
            else
                return BadRequest("Password week");



        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
