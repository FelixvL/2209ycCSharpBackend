using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextSkillsDB
{
    public class UserGoals
    {
        public int UserId;
        public int GoalId;

        public User User;
        public Goal Goal;
    }
}
