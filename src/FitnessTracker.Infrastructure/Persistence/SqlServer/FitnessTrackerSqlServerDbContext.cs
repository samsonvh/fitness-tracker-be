using FitnessTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Persistence.SqlServer
{
    public class FitnessTrackerSqlServerDbContext : DbContext
    {
        public FitnessTrackerSqlServerDbContext(DbContextOptions<FitnessTrackerSqlServerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FitnessTrackerSqlServerDbContext).Assembly);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<PersonalProfile> PersonalProfiles { get; set; }

        public DbSet<TrainingSpecialization> TrainingSpecializations { get; set; }
        public DbSet<TrainerSpecialization> TrainerSpecializations { get; set; }
        public DbSet<ExerciseSpecialization> ExerciseSpecializations { get; set; }

        public DbSet<TrainingExercise> TrainingExercises { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }

        public DbSet<TrainingSessionLog> TrainingSessionLogs { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }

        public DbSet<WeightGoal> WeightGoals { get; set; }
        public DbSet<TrainingPlanGoal> TrainingPlanGoals { get; set; }
        public DbSet<TrainingSessionGoal> TrainingSessionGoals { get; set; }
    }
}
