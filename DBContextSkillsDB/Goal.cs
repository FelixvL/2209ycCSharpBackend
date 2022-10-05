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
    public class Doel
    {
        public int Id { get; set; }
        public string Naam { get; set; } = "Default";
        public int Belangrijkheid { get; set; }
        public List<User> Users = new List<User>();

        public Doel(string naam, int belangrijkheid)
        {
            this.Naam = naam;
            this.Belangrijkheid = belangrijkheid;
        }
        public Doel() {}
    }
}
