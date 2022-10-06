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

        public UserController(SkillDBContext db) { 
            _db = db;
        }

        //User login
        [HttpPost("user/login")]
        public string POST([FromBody] JsonElement userinput)
        {
            object message = new { Message = " " };

            foreach (User user in _db.users)
            {
                if (user.UserNaam == userinput.GetProperty("username").ToString())
                {
                    if (user.Password == userinput.GetProperty("password").ToString())
                    {
                        //If username exists AND password is correct, send back json. In client store it in a localStorage
                        var userInfo = new
                        {
                            id = user.Id,
                            username = user.UserNaam,
                            name = user.Naam,
                            email = user.Email,
                        };
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
            foreach (Doel goal in _db.doelen)
            {
                if (goal.Id == doelID)
                {
                    user.addDoel(goal);
                }
            }
        }

        //---------------------------------------------------------------------------------
        //register user

        // Add user
        /*[HttpGet("addUser/{input}")]
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
        }*/

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
        //-------------------------------------------------------------------------





        //-------------------------------------------------------------------------
        //USER DETAILS

        // GET: api/<UserController>
        /*[HttpPost("getUserDetails")]
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
        }*/

        // Change user
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
    }
}