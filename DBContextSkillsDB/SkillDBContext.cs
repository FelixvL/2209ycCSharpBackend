using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextSkillsDB
{
    public class SkillDBContext : DbContext
    {
        public SkillDBContext(DbContextOptions options) : base(options) { }
        [AllowNull]
        public DbSet<Doel> doelen { get; set; }
        [AllowNull]
        public DbSet<SubGoal> subgoal { get; set; }
        [AllowNull]
        public DbSet<User> users { get; set; }
    }
}
