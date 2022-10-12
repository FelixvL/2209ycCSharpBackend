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
    }
}
