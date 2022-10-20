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
    public class SubGoal
    {
        public int Id { get; set; }
        public string name { get; set; } = "Default";
        public string description { get; set; } = "Default";
        private Goal goal;

        public SubGoal(string name, Goal goal, string description)
        {
            this.name = name;
            this.goal = goal;
            this.description = description;
        }

        public SubGoal() { }
    }
}