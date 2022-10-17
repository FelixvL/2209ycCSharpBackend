using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using System.Text.Json.Nodes;

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
            return goals;
        }



        [HttpGet("addGoal/{name}/{category}/{description}/{maximumpoints}/{priority}")]
        public void AddGoal(string name, string category, string description, int maximumpoints, int priority)
        {
            Goal d = new Goal(name, category, description, maximumpoints, priority);
            _db.goals.Add(d);
            _db.SaveChanges();
        }


        //returns goal (and subgoals of the goal)
        [HttpGet("getGoal/{givengoalid}")]
        public JsonResult PostGoal(int givengoalid)
        {
            var goalQuery = _db.goals.Find(givengoalid);

            //This query always seems to return all the subgoals
            var subgoalQuery = from GoalSubGoal in _db.Set<GoalSubGoal>()
                        join SubGoal in _db.Set<SubGoal>()
                        on GoalSubGoal.SubGoalID equals SubGoal.Id
                        select new { GoalSubGoal.GoalID, GoalSubGoal.SubGoalID, SubGoal.name, SubGoal.description };


            string goalJson = JsonSerializer.Serialize(goalQuery);
            string subgoalJson = JsonSerializer.Serialize(subgoalQuery);

            var obj1 = JsonObject.Parse(goalJson);
            var obj2 = JsonObject.Parse(subgoalJson);

            var result = new JsonObject();
            result.Add("goal", obj1);
            result.Add("subgoal", obj2);

            return new JsonResult(result);
        }
    }
}
