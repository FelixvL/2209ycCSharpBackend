using DBContextSkillsDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Text.Json;

namespace CSharpSkillsAppAPI
{
    //---------------------------------------------------------------------------------
    //API CONTROLLER

    [Route("api/[controller]")]
    [ApiController]
    public class UserGoalController : ControllerBase
    {
        private SkillDBContext _db;

        public UserGoalController(SkillDBContext db)
        {
            _db = db;
        }

        //---------------------------------------------------------------------------------
        //USERGOAL ENDPOINTS

        [HttpPost("AddUserGoal")]
        public string AddUserGoal([FromBody] JsonElement userinput)
        {
            if (Int32.TryParse(userinput.GetProperty("goalid").ToString(), out int goalID) && 
                Int32.TryParse(userinput.GetProperty("userid").ToString(), out int userID))
            {
                try
                {
                    UserGoal newRelation = new UserGoal();
                    newRelation.UserId = userID;
                    newRelation.GoalId = goalID;
                    _db.usergoal.Add(newRelation);
                    _db.SaveChanges();
                    return "saved";
                }
                catch (DbUpdateException e)
                {
                    return "Failed to add UserGoal to database.";
                }
            } else
            {
                return "goalid/userid not found or input was not a valid integer.";
            }
        }

        [HttpPost("RemoveUserGoal")]
        public string RemoveUserGoal([FromBody] JsonElement userinput)
        {
            if (Int32.TryParse(userinput.GetProperty("goalid").ToString(), out int goalID) &&
                Int32.TryParse(userinput.GetProperty("userid").ToString(), out int userID))
            {
                try
                {
                    UserGoal newRelation = new UserGoal();
                    newRelation.UserId = userID;
                    newRelation.GoalId = goalID;
                    _db.usergoal.Remove(newRelation);
                    _db.SaveChanges();
                    return "saved";
                }
                catch (DbUpdateException e)
                {
                    return "Failed to remove UserGoal from database.";
                }
            }
            else
            {
                return "goalid/userid not found or input was not a valid integer.";
            }
        }

        [HttpGet("AddUserGoalManually/{userID}/{goalID}")]
        public void AddUserGoal(int userID, int goalID)
        {
            {
                try
                {
                    UserGoal newRelation = new UserGoal();
                    newRelation.UserId = userID;
                    newRelation.GoalId = goalID;
                    _db.usergoal.Add(newRelation);
                    _db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine("Failed to add UserGoal to database.");
                }
            }
        }



        [HttpPost("GetGoalsFromUser")]
        public JsonResult GetGoalsFromUser([FromBody] JsonElement userinput)
        {
            Int32.TryParse(userinput.GetProperty("userId").ToString(), out int userID);
            List<int> goalIds = new List<int>();
            ArrayList goals = new ArrayList();
            foreach (UserGoal usergoal in _db.usergoal)
            {
                if (usergoal.UserId == userID)
                {
                    Console.WriteLine(usergoal.GoalId);
                    goalIds.Add(usergoal.GoalId);
                }
            }

            foreach (int goalid in goalIds)
            {
                foreach (Goal goal in _db.goals)
                {
                    if (goalid == goal.Id)
                    {
                        goals.Add(goal);
                    }
                }
            }
            return new JsonResult(goals);
        }

        [HttpPost("GetUsersFromGoal")]
        public JsonResult GetUsersFromGoal([FromBody] JsonElement userinput)
        {
            Int32.TryParse(userinput.GetProperty("goalid").ToString(), out int goalID);
            List<int> userIds = new List<int>();
            ArrayList users = new ArrayList();
            foreach (UserGoal usergoal in _db.usergoal)
            {
                if (usergoal.GoalId == goalID)
                {
                    userIds.Add(usergoal.UserId);
                }
            }

            foreach (int userid in userIds)
            {
                foreach (User user in _db.users)
                {
                    if (userid == user.Id)
                    {
                        users.Add(user);
                    }
                }
            }
            return new JsonResult(users);
        }
    }
}
