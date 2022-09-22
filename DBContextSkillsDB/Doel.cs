using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBContextSkillsDB
{
    public class Doel
    {
        public int Id { get; set; }

        [AllowNull]
        public string Naam { get; set; }
        public int Belangrijkheid { get; set; }
        public Doel(string naam, int belangrijkheid)
        {
            this.Naam = naam;
            this.Belangrijkheid = belangrijkheid;
        }
        public Doel() { }
    }
}
