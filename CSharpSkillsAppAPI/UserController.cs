using DBContextSkillsDB;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using System;
using System.Net;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
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

        public UserController(SkillDBContext db)
        {
            _db = db;
        }


        [HttpPost("user/login")]
        public string POST([FromBody] JsonElement userinput)
        {
            object message = new { Message = " " };

            foreach (User user in _db.users)
            {
                if (user.UserName == userinput.GetProperty("username").ToString())
                {
                    if (user.Password == userinput.GetProperty("password").ToString())
                    {
                        //If username exists AND password is correct, send back json. In client store it in a localStorage
                        var userInfo = new
                        { id = user.Id };
                        var jsonInfo = JsonSerializer.Serialize(userInfo);
                        return jsonInfo.ToString();
                    }
                    else
                    {
                        message = new { Message = "Wrong password" };
                        var jsonPass = JsonSerializer.Serialize(message);
                        return jsonPass.ToString();
                    }
                }
            }

            message = new { Message = "User does not exist" };
            var json = JsonSerializer.Serialize(message);
            return json.ToString();
        }

        //Add goal to user
        [HttpGet("addDoelToUser/{user}/{doelID}")]
        public void AddGoalToUser(User user, int doelID)
        {
            foreach (Goal goal in _db.goals)
            {
                if (goal.Id == doelID)
                {
                    user.addGoal(goal);
                }
            }
        }

        //---------------------------------------------------------------------------------
        //register user


        // Add user
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

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (User user in _db.users)
            {
                if (user.Id == id)
                {
                    _db.users.Remove(user);
                }
            }
            _db.SaveChanges();
        }

        //-------------------------------------------------------------------------





        //-------------------------------------------------------------------------
        //USER DETAILS

        // GET: api/<UserController>
        [HttpPost("getUserDetails")]
        public JsonResult GetUserDetails(JsonElement jsonElem)
        {
            try
            {
                int givenid = Int32.Parse(jsonElem.GetProperty("userId").ToString());
                JsonResult result = new JsonResult(_db.users.Find(givenid));
                return result;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                return new JsonResult(e);
                //want to return something different, don't know what
            }
        }

        // Change user
        [HttpPut("changeUserDetails")]
        public JsonResult ChangeUserDetails(JsonElement jsonElem)
        {
            User user;

            int givenid = Int32.Parse(jsonElem.GetProperty("id").ToString());
            int housenumber = Int32.Parse(jsonElem.GetProperty("houseNumber").ToString());

            try
            {
                user = _db.users.Find(givenid);
                System.Diagnostics.Debug.WriteLine("USER FOUND", jsonElem.ToString());

                //Add checks for sql injection
                if (user.Name != jsonElem.GetProperty("name").ToString())
                {
                    user.Name = jsonElem.GetProperty("name").ToString();
                }
                /*if (user.UserName != username)
                {
                    user.UserName = username;
                }*/
                if (user.Email != jsonElem.GetProperty("email").ToString())
                {
                    user.Email = jsonElem.GetProperty("email").ToString();
                }
                if (user.Street != jsonElem.GetProperty("street").ToString())
                {
                    user.Street = jsonElem.GetProperty("street").ToString();
                }
                if (user.HouseNumber != housenumber)
                {
                    user.HouseNumber = Int32.Parse(jsonElem.GetProperty("houseNumber").ToString());
                }
                if (user.PostalCode != jsonElem.GetProperty("postalCode").ToString())
                {
                    user.PostalCode = jsonElem.GetProperty("postalCode").ToString();
                }
                if (user.City != jsonElem.GetProperty("city").ToString())
                {
                    user.City = jsonElem.GetProperty("city").ToString();
                }
                if (user.Country != jsonElem.GetProperty("country").ToString())
                {
                    user.Country = jsonElem.GetProperty("country").ToString();
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


        [HttpPost("addUser/{name}/{username}/{email}/{password}/{dateofbirth}/{street}/{housenumber}/{postalcode}/{city}/{country}/{isexpert}")]
        public bool GetAddUserWithInput(string name, string username, string email,
            string password, DateTime dateofbirth, string street,
            int housenumber, string postalcode, string city,
            string country, bool isexpert)
        {
            try
            {
                _db.users.Add(new User(name, username, email, password, dateofbirth, street, housenumber, postalcode, city, country, false));
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                return false;
            }
        }



        [HttpGet("addGoalToUser/{activeUser}/{goalID}")]
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
                activeUser.addGoal(goalToAdd);
                _db.SaveChanges();
                Console.WriteLine(activeUser.Goals);
            }
        }
        //-------------------------------------------------------------------------




        //-------------------------------------------------------------------------
        //EXAMPLES?
        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] Goal goal)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        { }
    }
}