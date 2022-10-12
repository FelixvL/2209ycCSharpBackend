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
        public DbSet<Goal> goals { get; set; }
        [AllowNull]
        public DbSet<SubGoal> subgoal { get; set; }
        [AllowNull]
        public DbSet<User> users { get; set; }
        public DbSet<UserGoal> usergoal { get; set; }
        public DbSet<GoalSubGoal> goalsubgoal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGoal>().HasKey(sc => new { sc.UserId, sc.GoalId });
            modelBuilder.Entity<GoalSubGoal>().HasKey(sc => new { sc.GoalID, sc.SubGoalID });
        }


    }
}
