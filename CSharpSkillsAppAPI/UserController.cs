using DBContextSkillsDB;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpSkillsAppAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private SkillDBContext _db;


        public UserController(SkillDBContext db) { 
            _db = db;
        }
        
        
        // GET: api/<UserController>
        [HttpGet("addUser/{input}")]
        public IEnumerable<User> GetAddUserWithInput(string input)
        {
            User user= new User(input, $"User{input}", $"{input}@Hotmail.com", "Password", 1, 1, 1, false);
            _db.users.Add(user);
            _db.SaveChanges();
            return _db.users;
        }

        // GET: api/<UserController>
        [HttpGet("addUser")]
        public IEnumerable<User> GetAddUser()
        {
            User user = new User();
            _db.users.Add(user);
            _db.SaveChanges();
            return _db.users;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("login")]
        public string loginUser([FromBody] dynamic loginJson)
        {
            //For now return appel (to see if its works). Should ofcourse be code
            return "appel";
        }
    }
}
