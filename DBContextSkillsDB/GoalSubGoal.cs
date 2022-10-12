using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextSkillsDB
{
    public class GoalSubGoal
    {
        public int GoalID { get; set; }
        public Goal goal;
        public int SubGoalID { get; set; }
        public SubGoal subGoal;
    }
}
