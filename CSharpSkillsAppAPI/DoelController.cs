using DBContextSkillsDB;
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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            Doel d = new Doel();
            d.Naam = "Frits";
            _db.doelen.Add(d);
            _db.SaveChanges();
            return new string[] { "DIT GA IK ZIEN", "value2" };
        }

        [HttpGet("tweede")]
        public IEnumerable<Doel> GetTweede()
        {
            return _db.doelen;
        }
        [HttpGet("derde/{input}")]
        public IEnumerable<Doel> GetDerde(string input)
        {
            Doel doel= new Doel(input, 2);
            _db.doelen.Add(doel);
            _db.SaveChanges();
            return _db.doelen;
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
