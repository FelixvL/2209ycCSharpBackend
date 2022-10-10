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



        [HttpGet("addGoal/{name}/{priority}")]
        public void AddGoal()
        {
            Goal d = new Goal("testgoal", 1);
            _db.goals.Add(d);
            _db.SaveChanges();
        }

        [HttpPost("tweede")]
        public IEnumerable<Goal> GetAllGoals()
        {
            return _db.goals;
        }

        [HttpPost("postgoal/{givenid}")]
        public JsonResult PostGoal(int givenid)
        {
            return new JsonResult(_db.goals.Find(givenid)); 
        }


        //=================================EXAMPLES=================================
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
