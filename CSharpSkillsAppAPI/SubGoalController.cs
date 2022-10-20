using DBContextSkillsDB;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using System.Text.Json.Nodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpSkillsAppAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGoalController : ControllerBase
    {
        private SkillDBContext _db;


        public SubGoalController(SkillDBContext db) { 
            _db = db;
        }

        //returns goal (and subgoals of the goal)
        [HttpGet("getSubGoal/{givensubgoalid}")]
        public JsonResult getSubGoal(int givensubgoalid)
        {
            //var goalQuery = _db.goals.Find(givengoalid);

            var subgoalQuery = _db.subgoal.Find(givensubgoalid);
            var goalId = (from r in _db.subgoal
                         where r.Id == givensubgoalid
                         select r.GoalId).FirstOrDefault();
            var goalQuery = _db.goals.Find(goalId);

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
