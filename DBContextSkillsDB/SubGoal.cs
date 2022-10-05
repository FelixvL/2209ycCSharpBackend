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
        private string name = "Default";
        private Doel goal;
        private string description;

        public SubGoal(string name, Doel goal, string description)
        {
            this.name = name;
            this.goal = goal;
            this.description = description;
        }

        public SubGoal(){}

        public void setName(String name)
        {
            this.name = name;
        }


        public int getId()
        {
            return Id;
        }

        public void setId(int Id)
        {
            this.Id = Id;
        }

        public String getName()
        {
            return name;
        }

        public Doel getGoal()
        {
            return goal;
        }

        public String getDescription()
        {
            return description;
        }
    }
}
