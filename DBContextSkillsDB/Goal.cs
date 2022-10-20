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
        public string Category { get; set; } = "Default";
        public string Description { get; set; } = "Default";
        //public int MaximumPoints { get; set; }
        //public int Priority { get; set; }
        public string FileName { get; set; } = "default";

        public List<User> Users = new List<User>();

        public Goal(string name, string category, string description /*, int maximumpoints, int priority*/)
        {
            this.Name = name;
            this.Category = category;
            this.Description = description;
            //this.MaximumPoints = maximumpoints;
            //this.Priority = priority;
        }
        public Goal() {}

        public List<User> getUsers()
        {
            return this.Users;
        }

        public void adduser(User user)
        {
            this.Users.Add(user);
        }
        public void removeGoal(User user)
        {
            this.Users.Remove(user);
        }
    }
}
