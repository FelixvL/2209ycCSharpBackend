using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DBContextSkillsDB
{
    public class User
    {

        [Key]
        public int Id { set; get; }
        public string Naam { set; get; }
        public string UserNaam { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public int Points { set; get; } = 0;
        public int GoalProgress { set; get; } = 0;
        public int SubGoalProgress { set; get; } = 0;
        public bool IsExpert { set; get; }

        public List<Doel> Doelen = new List<Doel>();


        public List<Doel> getDoelen()
        {
            return this.Doelen;
        }
        public void addDoel(Doel doel)
        {
            this.Doelen.Add(doel);
            Console.WriteLine(Doelen);
        }
        public void removeDoel(Doel doel)
        {
            this.Doelen.Remove(doel);
        }


        public User(string naam, string usernaam, string email, string password, bool isexpert)
        {
            this.Naam = naam;
            this.UserNaam = usernaam;
            this.Email = email;
            this.Password = password;
            this.IsExpert = isexpert;
        }
        public User() { }
    }
}
