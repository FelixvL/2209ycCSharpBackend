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


        //returns goal
        [HttpPost("postgoal/{givengoalid}")]
        public JsonResult PostGoal(int givengoalid)
        {
            return new JsonResult(_db.goals.Find(givengoalid)); 
        }

        //returns all subgoals related to goal
        [HttpPost("postsubgoals/{givengoalid}")]
        public JsonResult PostSubGoals(int givengoalid)
        {
            var query = from GoalSubGoal in _db.Set<GoalSubGoal>()
                        join SubGoal in _db.Set<SubGoal>()
                        on GoalSubGoal.SubGoalID equals SubGoal.Id
                        select new { GoalSubGoal.GoalID, GoalSubGoal.SubGoalID, SubGoal.name, SubGoal.description };

            return new JsonResult(query);
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
