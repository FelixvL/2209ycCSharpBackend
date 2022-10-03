using DBContextSkillsDB;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using System;
using System.Net;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

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

        //See all the users in db (for testing purposes)
        [HttpGet("all")]
        public List<User> GetUser(int id)
        {
           List<User> userList = new List<User>();
           foreach(User user in _db.users)
           {
                userList.Add(user);
           }
            return userList;
        }

        [HttpPost("user/login")]
        public IActionResult POST([FromBody] JsonElement userinput)
        {
            foreach (User user in _db.users)
            {
                if (user.UserNaam == userinput.GetProperty("username").ToString()){
                    if(user.Password == userinput.GetProperty("password").ToString()){
                        //If username exists AND password is correct, set cookie and send to the client
                        var response = HttpContext.Response;
                        response.Cookies.Append("naam", user.Naam, new CookieOptions() { SameSite = SameSiteMode.Lax});

                        //TODO: Hash username and password, save that in cookie

                        //HttpCookie is accessible from Request.Cookies
                        return Ok(response.Cookies);
                    }
                    else{
                        return Problem("Password incorrect");
                    }
                }
            }
            return Problem("No user found");
        }

        [HttpPost("cookiecheck")]
        public IActionResult getCookieheader()
        {
            System.Diagnostics.Debug.WriteLine("CLIENT REQUEST", HttpContext.Request);
            return Ok(HttpContext.Request);
        }
        
        // GET: api/<UserController>
        [HttpGet("addUser/{input}")]
        public bool GetAddUserWithInput(string input)
        {
            foreach (User user in _db.users)
            {
                if (user.UserNaam == input)
                {
                    Console.WriteLine("That username already exists");
                    return false;
                //} else if (user.Email == emailInput) {
                    //Console.WriteLine("That Email is already in use");
                    //return false;
                }
            }
            User potentialUser = new User(input, input, $"{input}@Hotmail.com", "Password", false);
            _db.users.Add(potentialUser);
            _db.SaveChanges();
            return true;
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
            foreach(User user in _db.users)
            {
                if (user.Id == id)
                {
                    _db.users.Remove(user);
                }
            }
            _db.SaveChanges();
        }

        [HttpPost("login")]
        public string loginUser([FromBody] dynamic loginJson)
        {
            //For now return appel (to see if its works). Should ofcourse be code
            return "appel";
        }
    }
}
