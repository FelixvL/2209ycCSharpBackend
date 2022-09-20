using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextSkillsDB
{
    public class SkillDBContext : DbContext
    {
        public SkillDBContext(DbContextOptions options): base(options) { }
        public DbSet<Doel> doelen { get; set; }
    }
}
