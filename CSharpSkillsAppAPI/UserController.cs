using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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



        [HttpPost("user/login")]
        public bool POST([FromBody] JsonElement userinput)
        {
            foreach (User user in _db.users)
            {
                if (user.UserNaam == userinput.GetProperty("username").ToString())
                {
                    if(user.Password == userinput.GetProperty("password").ToString())
                    {
                        Console.WriteLine("Login succesful!");
                        return true;
                    } else
                    {
                        Console.WriteLine("Wrong password");
                        return false;
                    }
                }
            }
            Console.WriteLine("User not found");
            return false;
        }
        





        
        // GET: api/<UserController>
        [HttpGet("addUser/{input}")]
        public IEnumerable<User> GetAddUserWithInput(string input)
        {
            User user = new User(input, input, $"{input}@Hotmail.com", "Password", false);
            _db.users.Add(user);
            _db.SaveChanges();
            return _db.users;
        }
        [HttpGet("addDoelToUser/{user}/{doelID}")]
        public void AddGoalToUser(User user, int doelID)
        {
            foreach (Doel goal in _db.doelen)
            {
                if (goal.Id == doelID)
                {
                    user.addDoel(goal);
                }
            }
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
