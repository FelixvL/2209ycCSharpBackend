﻿using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpSkillsAppAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoelController : ControllerBase
    {
        private SkillDBContext _db;


        public DoelController(SkillDBContext db) { 
            _db = db;
        }
        
        
        // GET: api/<DoelController>



        [HttpGet("addGoal/{name}/{priority}")]
        public void AddGoal()
        {
            Goal d = new Goal("testgoal", 1);
            _db.goals.Add(d);
            _db.SaveChanges();
        }

        [HttpGet("tweede")]
        public IEnumerable<Goal> GetTweede()
        {
            return _db.goals;
        }
        [HttpGet("derde/{input}")]
        public IEnumerable<Goal> GetDerde(string input)
        {
            Goal doel= new Goal(input, 2);
            _db.goals.Add(doel);
            _db.SaveChanges();
            return _db.goals;
        }

        // GET api/<DoelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
