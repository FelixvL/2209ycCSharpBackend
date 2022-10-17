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
        public int GoalId { get; set; }
        public string Name { get; set; } = "Default";
        public string Description { get; set; } = "Default";
        public int Points { get; set; }

        public SubGoal(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public SubGoal() { }
    }
}