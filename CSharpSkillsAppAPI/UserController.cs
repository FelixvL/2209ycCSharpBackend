using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
                if (user.UserName == userinput.GetProperty("username").ToString())
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
        [HttpGet("addUser/{name}/{username}/{email}/{password}/{dateofbirth}/{street}/{housenumber}/{postalcode}/{city}/{country}/{isexpert}")]
        public bool GetAddUserWithInput(string name, string username, string email, string password, DateTime dateofbirth, string street, int housenumber, string postalcode, string city, string country, bool isexpert)
        {
            foreach (User user in _db.users)
            {
                if (user.UserName == username)
                {
                    Console.WriteLine("That username already exists");
                    return false;
                //} else if (user.Email == emailInput) {
                    //Console.WriteLine("That Email is already in use");
                    //return false;
                }
            }
            User potentialUser = new User(name, username, email, password, dateofbirth, street, housenumber, postalcode, city, country, false);
            _db.users.Add(potentialUser);
            _db.SaveChanges();
            return true;
        }

        [HttpGet("addDoelToUser/{activeUser}/{goalID}")]
        public void AddGoalToUser(int userID, int goalID)
        {
            User activeUser = null;
            Goal goalToAdd = null;
            foreach (Goal goal in _db.goals)
            {
               if (goal.Id == goalID)
                {
                    goalToAdd = goal;
                }
            }
            foreach (User user in _db.users) { 
                if (user.Id == userID)
                {
                    activeUser = user;
                }
            }
            if((activeUser != null) && (goalToAdd != null))
            {
                activeUser.addDoel(goalToAdd);
                _db.SaveChanges();
                Console.WriteLine(activeUser.Goals);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] Goal goal)
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
            foreach(User user in _db.users)
            {
                if (user.Id == id)
                {
                    _db.users.Remove(user);
                }
            }
            _db.SaveChanges();
        }
    }
}
