using TechJobsPersistentAutograded.Models;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistentAutograded.Data
{
    public class JobDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }


        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        {
        }
        //provide additional configuration for the data store.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSkill>()
                .HasKey(j => new { j.JobId, j.SkillId });
        }
    }
}
//this class for Migration to create all the tables in the database
//OnModelCreating method that can be used for configure the primary key
