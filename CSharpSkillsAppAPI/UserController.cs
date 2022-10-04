using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        // GET: api/<UserController>
        [HttpPost("getUserDetails")]
        public User GetUserDetails(int givenid)
        {
            //kan hier try catch implementeren
            //ff vragen hoe dat hier het meest handig kan

            if (_db.users.Find(givenid) != null)
            {
                return _db.users.Find(givenid);
            }
            else
            {
                return null;
            }
        }

        // PUT: api/<UserController>
        [HttpPut("changeUserDetails")]
        public void ChangeUserDetails(int givenid, String name, String username, 
            String email/*, String password*/)
        {
            _db.users.Find(givenid).setNaam(name);
            
            //implement try catch/if else to check if usn is already in use
            _db.users.Find(givenid).UserNaam = username;
            
            //implement try catch/if else to check if email is already in use
            _db.users.Find(givenid).Email = email;

            //Do we want to be able to change a password from here?
            //
            //If yes, implement call to password method declared in user creation
            //If that doesn't exist, create said function
            //
            //If no, disregard

            _db.SaveChanges();

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
    }
}
