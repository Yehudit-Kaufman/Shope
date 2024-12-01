using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entite;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        IServiceUser service ;
        public UserController(IServiceUser _serviceUser)
        {
            service = _serviceUser;
        }
        
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    using (StreamReader reader = System.IO.File.OpenText(filePath))
        //    {
        //        string? currentUserInFile;
        //        while ((currentUserInFile = reader.ReadLine()) != null)
        //        {
        //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
        //            if (user.UserId == id)
        //                return "USER TO CLIENT";
        //        }
        //    }
        //    return "not user found";

        //}

        // POST api/<UserController>
        [HttpPost]
        //public ActionResult<User> Post([FromBody] User user)
        //{
        //    User newUser = service.AddUser(user);
        //    return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUser);

        //}
        public async Task<ActionResult<User>>  Post([FromBody] User user)
        {
            User newUser =await service.AddUser(user);
            if (newUser != null)
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUser);
            else
                return BadRequest();

        }
        [HttpPost]
        [Route("password")]
        public int PostPassword([FromQuery] string password)
        {

            return service.CheckPassword(password);

        }

        [HttpPost("login")]
        public async  Task<ActionResult<User>>  PostLogin([FromQuery] string UserName,string Password)
        {
            User user = await service.Login(UserName, Password);
                    if(user!=null)
                        return Ok(user);
          
            return NoContent();


        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User value)
        {
           await service.UpdateUser(id, value);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
