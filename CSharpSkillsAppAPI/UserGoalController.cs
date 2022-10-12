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
        public void AddUserGoal([FromBody] JsonElement userinput)
        {
            Int32.TryParse(userinput.GetProperty("goalid").ToString(), out int goalID);
            Int32.TryParse(userinput.GetProperty("userid").ToString(), out int userID);
            User activeUser = null;
            Goal goalToAdd = null;
            foreach (Goal goal in _db.goals)
            {
                if (goal.Id == goalID)
                {
                    goalToAdd = goal;
                }
            }
            foreach (User user in _db.users)
            {
                if (user.Id == userID)
                {
                    activeUser = user;
                }
            }
            if ((activeUser != null) && (goalToAdd != null))
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
                    Console.WriteLine("Cannot add duplicate User-Goal connections");
                }
            }
        }



        [HttpPost("GetGoalsFromUser")]
        public JsonResult GetGoalsFromUser([FromBody] JsonElement userinput)
        {
            Int32.TryParse(userinput.GetProperty("userid").ToString(), out int userID);
            List<int> goalIds = new List<int>();
            ArrayList goals = new ArrayList();
            foreach (UserGoal usergoal in _db.usergoal)
            {
                if (usergoal.UserId == userID)
                {
                    goalIds.Add(usergoal.GoalId);
                }
            }
            if (goalIds.Count != 0)
            {
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
            else
            {
                return new JsonResult(false);
            }
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
            if (userIds.Count != 0)
            {
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
            else
            {
                return new JsonResult(false);
            }
        }
    }
}
