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
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpSkillsAppAPI
{
    //---------------------------------------------------------------------------------
    //API CONTROLLER

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private SkillDBContext _db;

        public UserController(SkillDBContext db)
        {
            _db = db;
        }


        //---------------------------------------------------------------------------------
        //LOGIN USER

        [HttpPost("user/login")]
        public string LoginPOST([FromBody] JsonElement userinput)
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
                        {
                            id = user.Id,
                            username = user.UserName,
                            name = user.Name,
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


        //---------------------------------------------------------------------------------
        //REGISTER USER

        [HttpPost("addUser")]
        public bool AddUserPOST([FromBody] JsonElement userinput)
        {
            try
            {
                if (userinput.GetProperty("name").ToString() != null
                    && userinput.GetProperty("username").ToString() != null
                    && userinput.GetProperty("email").ToString() != null
                    && userinput.GetProperty("password").ToString() != null)
                {
                    User newUser = new User();
                    newUser.Name = userinput.GetProperty("name").ToString();
                    newUser.UserName = userinput.GetProperty("username").ToString();
                    newUser.Email = userinput.GetProperty("email").ToString();
                    newUser.Password = userinput.GetProperty("password").ToString();
                    newUser.IsExpert = bool.Parse(userinput.GetProperty("isexpert").ToString());
                    _db.users.Add(newUser);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateException e)
            {
                return false;
            }
        }



        [HttpPost("addUserManually/{name}/{username}/{email}/{password}/{dateofbirth}/{street}/{housenumber}/{postalcode}/{city}/{country}/{isexpert}")]
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

                if (user.Name != name)
                {
                    user.Name = name;
                }
                if (user.UserName != username)
                {
                    user.UserName = username;
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
        //DELETE USER

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
    }
}