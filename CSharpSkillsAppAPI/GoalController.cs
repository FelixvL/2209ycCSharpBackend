using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpSkillsAppAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private SkillDBContext _db;


        public GoalController(SkillDBContext db) { 
            _db = db;
        }


        // GET: api/<DoelController>
        [HttpGet("allGoals")]
        public List<Goal> GetAllGoals()
        {
            List<Goal> goals = new List<Goal>();
            foreach (Goal goal in _db.goals)
            {
                goals.Add(goal);
            }
            //var json = JsonSerializer.Serialize(goals);
            return goals;
        }



        [HttpGet("addGoal/{name}/{category}/{description}/{maximumpoints}/{priority}")]
        public void AddGoal(string name, string category, string description, int maximumpoints, int priority)
        {
            Goal d = new Goal(name, category, description, maximumpoints, priority);
            _db.goals.Add(d);
            _db.SaveChanges();
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
