using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using DBContextSkillsDB;


namespace DBContextSkillsDB
{
    [Index(nameof(User.UserNaam), IsUnique = true)]
    [Index(nameof(User.Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; } = "John Doe";
        public string UserNaam { get; set; } = "JD";
        public string Email { get; set; } = "JohnDoe@Hotmail.com";
        public string Password { get; set; } = "Password";
        public int Points { get; set; }
        public int GoalProgress { get; set; }
        public int SubGoalProgress { get; set; }
        public bool IsExpert { get; set; }

        public ICollection<Doel> Doel { get; set; }
 

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

        public User() {}
    }
}
