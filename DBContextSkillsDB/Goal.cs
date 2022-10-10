using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBContextSkillsDB
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default";
        public int Priority { get; set; }
        public List<User> Users = new List<User>();

        public Goal(string name, int priority)
        {
            this.Name = name;
            this.Priority = priority;
        }
        public Goal() {}

        public Goal getGoal()
        {
            return this;
        }
    }
}
