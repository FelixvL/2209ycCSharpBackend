using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

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
        

        //---------------------------------------------------------------------------------
        //REGISTER

        // GET: api/<UserController>
        [HttpGet("addUser/{input}")]
        public JsonResult GetAddUserWithInput(string input)
        {
            try
            {
                User user = new User(input, $"User{input}", $"{input}@Hotmail.com", "Password", 1, 1, 1, false);
                _db.users.Add(user);
                _db.SaveChanges();
                return new JsonResult(user);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return new JsonResult(e);
                //want to return something different, don't know what
            }
        }

        // GET: api/<UserController>
        [HttpGet("addUser")]
        public JsonResult GetAddUser()
        {
            try 
            { 
                User user = new User();
                _db.users.Add(user);
                _db.SaveChanges();
                return new JsonResult(user);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return new JsonResult(e);
                //want to return something different, don't know what
            }
        }
        //-------------------------------------------------------------------------





        //-------------------------------------------------------------------------
        //USER DETAILS

        // GET: api/<UserController>
        [HttpPost("getUserDetails")]
        public JsonResult GetUserDetails(int givenid)
        {
            try
            {
                JsonResult test = new JsonResult(_db.users.Find(givenid));
                return test;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                return new JsonResult(e);
                //want to return something different, don't know what
            }
        }

        // PUT: api/<UserController>
        [HttpPut("changeUserDetails")]
        public JsonResult ChangeUserDetails(int givenid, String name, String username, 
            String email)
        {
            User user;
            try
            {
                user = _db.users.Find(givenid);

                if (user.Naam != name) 
                {
                    user.Naam = name;
                }
                if (user.UserNaam != username)
                {
                    user.UserNaam = username;
                }
                if (user.Email != email)
                {
                    user.Email = email;
                }

                _db.SaveChanges();
                return new JsonResult(_db.users.Find(givenid));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                return new JsonResult(e);
                //want to return something different, don't know what
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return new JsonResult(e);
                //want to return something different, don't know what
            }
        }
        //-------------------------------------------------------------------------




        //-------------------------------------------------------------------------
        //EXAMPLES?
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
