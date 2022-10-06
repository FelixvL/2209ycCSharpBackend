using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.IO;
using System.Xml.Linq;


namespace DBContextSkillsDB
{
    [Index(nameof(User.UserName), IsUnique = true)]
    [Index(nameof(User.Email), IsUnique = true)]
    public class User {
        public int Id { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Street { set; get; }
        public int HouseNumber { set; get; }
        public string PostalCode { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public int Points { set; get; } = 0;
        public int GoalProgress { set; get; } = 0;
        public int SubGoalProgress { set; get; } = 0;
        public bool IsExpert { set; get; }

        public List<Goal> Goals = new List<Goal>();

        public User() {}

        public User(string name, string username, string email,
            string password, DateTime dateofbirth, string street,
            int housenumber, string postalcode, string city,
            string country, bool isexpert)
        {
            this.Name = name;
            this.UserName = username;
            this.DateOfBirth = dateofbirth;
            this.Street = street;
            this.HouseNumber = housenumber;
            this.PostalCode = postalcode;
            this.City = city;
            this.Country = country;
            this.Email = email;
            this.Password = password;
        }

        public List<Goal> getDoelen()
        {
            return this.Goals;
        }

        public void addGoal(Goal goal) {
            this.Goals.Add(goal);
            Console.WriteLine(Goals);
        }
        public void removeGoal(Goal goal) {
            this.Goals.Remove(goal);
        }
    }
}


