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
    public class User
    {

        private int Id { get; set; }

        private string Naam { get; set; }
        private string UserNaam { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private int Points { get; set; }
        private int GoalProgress { get; set; }
        private int SubGoalProgress { get; set; }
        private bool IsExpert { get; set; }

        private List<Doel> doelen = new List<Doel>();
        public List<Doel> getDoelen()
        {
            return doelen;
        }
        public void addDoel(Doel doel)
        {
            doelen.Add(doel);
        }
        public void removeDoel(Doel doel)
        {
            //doelen.Remove();
        }
 

        public User(string naam, string usernaam, string email, string password, int points, int goalprogress, int subgoalprogress, bool isexpert)
        {
            this.Naam = naam;
            this.UserNaam = usernaam;
            this.Email = email;
            this.Password = password;
            this.Points = points;
            this.GoalProgress = goalprogress;
            this.SubGoalProgress = subgoalprogress;
            this.IsExpert = isexpert;
        }
    }
}
