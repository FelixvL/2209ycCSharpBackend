using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextSkillsDB
{
    public class UserGoal
    {
        public int UserId { get; set; }
        public User user { get; set; }


        public int GoalId { get; set; }
        public Goal goal { get; set; }
    }
}
